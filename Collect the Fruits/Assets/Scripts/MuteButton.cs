using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    [SerializeField] private Image bgMusicButtonImage;
    [SerializeField] private Sprite soundOnSprite;
    [SerializeField] private Sprite soundOffSprite;
    [SerializeField] private AudioSource sceneAudioSource; // Reference to the audio source in the scene

     private void Start()
    {
        // Update button image based on PlayerPrefs data
        bgMusicButtonImage.sprite = PlayerPrefs.GetInt("MuteState", 0) == 1 ? soundOffSprite : soundOnSprite;

        // Set the initial state of the audio source in the scene
        sceneAudioSource.mute = PlayerPrefs.GetInt("MuteState", 0) == 1;
    }

    public void BGMusic()
    {
        AudioManager.Instance.ToggleMute(); // Use the AudioManager to control the global audio source
        bgMusicButtonImage.sprite = AudioManager.Instance.audioSource.mute ? soundOffSprite : soundOnSprite;

        // Toggle the mute state of the audio source in the scene
        //sceneAudioSource.mute = AudioManager.Instance.audioSource.mute;

        // Save the mute state in PlayerPrefs
        PlayerPrefs.SetInt("MuteState", AudioManager.Instance.audioSource.mute ? 1 : 0);
        PlayerPrefs.Save(); // Save PlayerPrefs immediately
    }
}