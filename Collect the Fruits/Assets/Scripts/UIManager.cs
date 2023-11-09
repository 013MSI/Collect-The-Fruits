using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{   
    public static UIManager Instance { get; private set; } // Singleton instance
    public TMP_Text[] textElements; // Reference to the TextMeshPro elements you want to change color

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject across scene changes
            // Get all the TextMeshPro elements in the scene
            textElements = FindObjectsOfType<TMP_Text>();

            // Set the initial color based on the saved index from PlayerPrefs
            UpdateUIColor();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateUIColor()
    {
        int selectedColorIndex = PlayerPrefs.GetInt("SelectedColorIndex", 0);

    if (UIColorButton.Instance != null && UIColorButton.Instance.colors != null)
    {
        foreach (TMP_Text textElement in textElements)
        {
            textElement.color = UIColorButton.Instance.colors[selectedColorIndex];
        }
    }

    PlayerPrefs.Save();
    }
}
