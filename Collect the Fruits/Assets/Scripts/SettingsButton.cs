using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    public void OpenSettings()
    {
        // Store the current scene name as the previous scene name
        GameManager.Instance.SetPreviousSceneName(SceneManager.GetActiveScene().name);

        // Load the settings scene
        SceneManager.LoadScene("Settings"); // Replace with your actual scene name
    }
}
