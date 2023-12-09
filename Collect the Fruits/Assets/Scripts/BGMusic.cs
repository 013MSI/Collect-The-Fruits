using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BGMusic : MonoBehaviour
{
    // public static BGMusic instance;
    public AudioSource audioSource;
 
    void Start()
    {
        // if (instance != null)
        //     Destroy(gameObject);
        // else
        // {
        //     instance = this;
        //     DontDestroyOnLoad(this.gameObject);
        // }

        if(audioSource == null){
            audioSource = GetComponent<AudioSource>();
        }

        audioSource.mute = true;

        AudioManager.Instance.audioSource.clip = audioSource.clip;
        AudioManager.Instance.audioSource.Play();
    }

    void Awake(){
        audioSource.mute = true;
    }
}
 