using UnityEngine;
using TMPro;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private TMP_Text bgMusicButtonText;
    [SerializeField] private AudioSource sceneAudioSource; // Reference to the audio source in the scene

     private void Start()
    {
        // Update button text based on PlayerPrefs data
        bgMusicButtonText.text = PlayerPrefs.GetInt("MuteState", 0) == 1 ? "X" : "O";

        // Set the initial state of the audio source in the scene
        sceneAudioSource.mute = PlayerPrefs.GetInt("MuteState", 0) == 1;
    }

    public void BGMusic()
    {
        AudioManager.Instance.ToggleMute(); // Use the AudioManager to control the global audio source
        bgMusicButtonText.text = AudioManager.Instance.audioSource.mute ? "X" : "O";

        // Toggle the mute state of the audio source in the scene
        sceneAudioSource.mute = AudioManager.Instance.audioSource.mute;

        // Save the mute state in PlayerPrefs
        PlayerPrefs.SetInt("MuteState", AudioManager.Instance.audioSource.mute ? 1 : 0);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately
    }
}