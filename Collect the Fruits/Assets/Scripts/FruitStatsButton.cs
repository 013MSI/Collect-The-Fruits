using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FruitStatsButton : MonoBehaviour
{
    [SerializeField] private Image fruitStatsButtonImage;
    [SerializeField] private Sprite fruitStatsOnSprite;
    [SerializeField] private Sprite fruitStatsOffSprite;

    private void Start()
    {
        fruitStatsButtonImage.sprite = (PlayerPrefs.GetInt("StatsState") == 1) ? fruitStatsOnSprite : fruitStatsOffSprite;
    }

    public void FruitStats()
    {
        StatsManager.Instance.ToggleText();
        UpdateButtonImage();
    }

    private void UpdateButtonImage()
    {
        int value = 0;
        if ((PlayerPrefs.GetInt("StatsState")) == 0)
        {
            value = 1;
        }
        else if ((PlayerPrefs.GetInt("StatsState")) == 1)
        {
            value = 0;
        }

        // Save the state in PlayerPrefs
        PlayerPrefs.SetInt("StatsState", value);
        //PlayerPrefs.Save(); // Save PlayerPrefs immediately

        fruitStatsButtonImage.sprite = (PlayerPrefs.GetInt("StatsState") == 1) ? fruitStatsOnSprite : fruitStatsOffSprite;
    }
}
