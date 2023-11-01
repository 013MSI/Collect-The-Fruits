using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    private float points = 0.0f;

    private int apples = 0;
    private int bananas = 0;
    private int cherries = 0;
    private int kiwis = 0;
    private int melons = 0;
    private int oranges = 0;
    private int pineapples = 0;
    private int strawberries = 0;
    

    [SerializeField] private TMP_Text pointsText;

    [SerializeField] private TMP_Text applesText;
    [SerializeField] private TMP_Text bananasText;
    [SerializeField] private TMP_Text cherriesText;
    [SerializeField] private TMP_Text kiwisText;
    [SerializeField] private TMP_Text melonsText;
    [SerializeField] private TMP_Text orangesText;
    [SerializeField] private TMP_Text pineapplesText;
    [SerializeField] private TMP_Text strawberriesText;

    [SerializeField] private AudioSource collectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            points = points + 0.5f;
            applesText.text = "Apples: " + apples;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Banana"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            bananas++;
            points = points + 1f;
            bananasText.text = "Bananas: " + bananas;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            points = points + 1.5f;
            cherriesText.text = "Cherries: " + cherries;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            kiwis++;
            points = points + 2f;
            kiwisText.text = "Kiwis: " + kiwis;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Melon"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            melons++;
            points = points + 2.5f;
            melonsText.text = "Melons: " + melons;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Orange"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            oranges++;
            points = points + 3f;
            orangesText.text = "Oranges: " + oranges;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            pineapples++;
            points = points + 3.5f;
            pineapplesText.text = "Pineapples: " + pineapples;
            pointsText.text = "Points: " + points;
        }

        if (collision.gameObject.CompareTag("Strawberry"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            strawberries++;
            points = points + 4f;
            strawberriesText.text = "Strawberries: " + strawberries;
            pointsText.text = "Points: " + points;
        }
    }
}
