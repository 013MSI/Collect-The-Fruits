using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Characters()
    {
        SceneManager.LoadScene("Characters");
    }

    public void Levels()
    {
        SceneManager.LoadScene("Levels");
    }
}
