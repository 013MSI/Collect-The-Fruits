using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Singleton instance
    public AudioSource audioSource;

    private void Awake()
    {
        // Ensure there is only one AudioManager instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep this GameObject across scene changes
        }
        else
        {
            Destroy(gameObject);
        }

        // Load mute state from PlayerPrefs and update audio source
        audioSource.mute = PlayerPrefs.GetInt("MuteState", 0) == 1;
    }

    // Toggle audio source mute state and save the state in PlayerPrefs
    public void ToggleMute()
    {
        audioSource.mute = !audioSource.mute;
        PlayerPrefs.SetInt("MuteState", audioSource.mute ? 1 : 0);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately
    }
}