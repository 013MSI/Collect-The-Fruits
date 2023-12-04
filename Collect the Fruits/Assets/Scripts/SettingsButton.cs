using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsButton : MonoBehaviour
{
    // public void OpenSettings()
    // {
    //     // Store the current scene name as the previous scene name
    //     GameManager.Instance.SetPreviousSceneName(SceneManager.GetActiveScene().name);

    //     // Load the settings scene
    //     SceneManager.LoadScene("Settings"); // Replace with your actual scene name
    // }


    private bool isPaused = false;

    void Start()
    {
        // Initially, the game is not paused
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void TogglePause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
           ResumeGame();
        }
    }

    void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;

        GameManager.Instance.SetPreviousSceneName(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        
        SceneManager.UnloadSceneAsync("Settings");
    }
}
