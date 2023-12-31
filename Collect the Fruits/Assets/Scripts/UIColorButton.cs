using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIColorButton : MonoBehaviour
{
    public static UIColorButton Instance { get; private set; } // Singleton instance

    public TMP_Text buttonText; // Reference to the TextMeshPro component on the button
    private int currentColorIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Load the selected color index from PlayerPrefs
        currentColorIndex = PlayerPrefs.GetInt("SelectedColorIndex");

        ApplyColor();
        UpdateButtonText();
    }

    public void ChangeColor()
    {
        currentColorIndex = (currentColorIndex + 1) % GameManager.Instance.colors.Length;
        ApplyColor();
        UpdateButtonText();

        // Save the selected color index to PlayerPrefs
        PlayerPrefs.SetInt("SelectedColorIndex", currentColorIndex);
    }

    private void ApplyColor()
    {
        TMP_Text[] textElements = FindObjectsOfType<TMP_Text>(true);
        foreach (TMP_Text textElement in textElements)
        {
            textElement.color = GameManager.Instance.colors[currentColorIndex];
        }
    }

    private void UpdateButtonText()
    {
        // Update the button text to display the current color index
        if (buttonText != null)
        {
            buttonText.text = currentColorIndex.ToString();
        }
    }
}
