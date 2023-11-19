using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private string previousSceneName;
    private int selectedColorIndex = 0;

    public Color[] colors;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                DontDestroyOnLoad(instance.gameObject); // Ensure the GameManager persists across scenes.
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void SetPreviousSceneName(string sceneName)
    {
        previousSceneName = sceneName;
    }

    public string GetPreviousSceneName()
    {
        return previousSceneName;
    }
    
    public int GetSelectedColorIndex()
    {
        return selectedColorIndex;
    }

    public void SetSelectedColorIndex(int colorIndex)
    {
        selectedColorIndex = colorIndex;
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}


