using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitStatsButton : MonoBehaviour
{
    [SerializeField] private TMP_Text fruitStatButtonText;

    private void Start()
    {
        UpdateButtonText();
    }

    public void FruitStats()
    {
        StatsManager.Instance.ToggleText();
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        fruitStatButtonText.text = StatsManager.Instance.IsTextActive(fruitStatButtonText) ? "X" : "O";

        // Save the state in PlayerPrefs
        PlayerPrefs.SetInt("StatsState", StatsManager.Instance.IsTextActive() ? 1 : 0);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately
    }
}
