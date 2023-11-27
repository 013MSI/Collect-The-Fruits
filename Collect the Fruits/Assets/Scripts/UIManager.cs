using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{   
    public TMP_Text[] textElements; // Reference to the TextMeshPro elements you want to change color

    private void Start()
    {
            // Get all the TextMeshPro elements in the scene
            textElements = FindObjectsOfType<TMP_Text>();

            // Set the initial color based on the saved index from PlayerPrefs
            UpdateUIColor();
    }

    public void UpdateUIColor()
    {
        int selectedColorIndex = PlayerPrefs.GetInt("SelectedColorIndex");

        if (GameManager.Instance != null && GameManager.Instance.colors != null)
        {
            foreach (TMP_Text textElement in textElements)
            {
                textElement.color = GameManager.Instance.colors[selectedColorIndex];
            }
        }
    }
}
