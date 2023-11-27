using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState {idle, running, jumping, falling}

    [SerializeField] private AudioSource jumpSoundEffect;

    
    public RuntimeAnimatorController ninjaFrogDefaultAnimatorController;
    public RuntimeAnimatorController pinkManOverrideController;
    public RuntimeAnimatorController maskDudeOverrideController;
    public RuntimeAnimatorController virtualGuyOverrideController;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        ChangePlayerAnimator();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
           jumpSoundEffect.Play();
           rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }

    
    public void ChangePlayerAnimator()
    {
        string animationOverrideKey = PlayerPrefs.GetString("AnimationOverrideKey");
        
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 

        if (player != null)
        {
            if (anim != null)
            {
                switch (animationOverrideKey)
            {
                case "pinkMan":
                    anim.runtimeAnimatorController = pinkManOverrideController;
                    break;
                case "maskDude":
                    anim.runtimeAnimatorController = maskDudeOverrideController;
                    break;
                case "virtualGuy":
                    anim.runtimeAnimatorController = virtualGuyOverrideController;
                    break;
                default:
                    anim.runtimeAnimatorController = ninjaFrogDefaultAnimatorController;
                    break;
                }
            }
            else
            {
                Debug.LogError("Player character does not have an Animator component.");
            }
        }
        else
        {
            Debug.LogError("Player character not found in the scene. Make sure it has the correct tag.");
        }
    }
}
