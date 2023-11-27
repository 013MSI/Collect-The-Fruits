using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance { get; private set; } // Singleton instance
    public List<TMP_Text> textSources;

    private void Awake()
    {
        // Ensure there is only one StatsManager instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject across scene changes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Load mute state from PlayerPrefs and update text sources
        foreach (var textObject in textSources)
        {
            if (textObject != null)
            {
                textObject.gameObject.SetActive(PlayerPrefs.GetInt("StatsState", 0) == 1);
            }
        }
    }

    // Toggle text source state and save the state in PlayerPrefs
    public void ToggleText()
    {
        foreach (var textObject in textSources)
        {
            if (textObject != null)
            {
                bool currentState = textObject.gameObject.activeSelf;
                textObject.gameObject.SetActive(!currentState);
            }
        }
    }

    // Check if any text source is active
    public bool IsTextActive()
    {
        return textSources.Exists(textObject => textObject != null && textObject.gameObject.activeSelf);
    }

    // Check if a specific text source is active
    public bool IsTextActive(TMP_Text textObject)
    {
        return textObject != null && textObject.gameObject.activeSelf;
    }
}
