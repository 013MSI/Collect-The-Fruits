using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeButton : MonoBehaviour
{
    public void ResumeGame()
    {
        string previousSceneName = GameManager.Instance.GetPreviousSceneName();

        if(GameManager.Instance.isPlaying == false)
        {
            if (!string.IsNullOrEmpty(previousSceneName))
            {
                //SceneManager.UnloadSceneAsync("Settings");
                SceneManager.LoadScene(previousSceneName);
            }
            else
            {
                Debug.LogError("No previous scene name found. Unable to resume.");
            }
        }
        else
        {
            Time.timeScale = 1f;
        
            SceneManager.UnloadSceneAsync("Settings");
        }
        
    }
}