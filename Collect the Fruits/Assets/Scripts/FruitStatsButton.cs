using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitStatsButton : MonoBehaviour
{
    [SerializeField] private TMP_Text fruitStatButtonText;

    private void Start()
    {
        fruitStatButtonText.text = (PlayerPrefs.GetInt("StatsState") == 1) ? "X" : "O";
    }

    public void FruitStats()
    {
        StatsManager.Instance.ToggleText();
        UpdateButtonText();
    }

    private void UpdateButtonText()
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

        fruitStatButtonText.text = (PlayerPrefs.GetInt("StatsState") == 1) ? "X" : "O";
    }
}
