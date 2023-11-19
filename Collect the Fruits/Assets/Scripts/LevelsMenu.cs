using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelsMenu : MonoBehaviour
{
    public Button level1Button;
    public Button level2Button;
    public Button level3Button;
    public Button level4Button;
    public Button level5Button;

    public Button resetButton;


    Color myBlue = new Color((220f / 255.0f), (251 / 255.0f), (253 / 255.0f), 1.0f);
    Color myGray = new Color((196 / 255.0f), (196 / 255.0f), (196 / 255.0f), 1.0f);

    private void Start()
    {
        // Assume that level 1 is always unlocked at the beginning
        PlayerPrefs.SetInt("Level1Unlocked", 1);
        PlayerPrefs.Save();

        // Update button colors and text based on unlocked levels
        UpdateButtonState(level1Button, 1);
        UpdateButtonState(level2Button, 2);
        UpdateButtonState(level3Button, 3);
        UpdateButtonState(level4Button, 4);
        UpdateButtonState(level5Button, 5);

        // Set up the reset button click event
        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetLevels);
        }
    }

    private void UpdateButtonState(Button button, int levelIndex)
    {
        Debug.Log("Checking button for Level " + levelIndex + ": " + button);
        
        // Check if the level is unlocked
        if (PlayerPrefs.GetInt("Level" + levelIndex + "Unlocked", 0) == 1)
        {
            // Set unlocked colors and update text
            button.interactable = true;
            button.GetComponent<Image>().color = myBlue; // Change to unlocked color
            button.GetComponentInChildren<TMP_Text>().color = Color.black;
            button.GetComponentInChildren<TMP_Text>().text = "" + levelIndex;
        }
        else
        {
            // Set locked colors and update text
            button.interactable = false;
            button.GetComponent<Image>().color = myGray; // Change to locked color
            button.GetComponentInChildren<TMP_Text>().color = Color.gray;
            button.GetComponentInChildren<TMP_Text>().text = "" + levelIndex;
        }
    }

    public void LoadLevel(int levelIndex)
    {
        // Check if the level is unlocked
        if (PlayerPrefs.GetInt("Level" + levelIndex + "Unlocked", 0) == 1)
        {
            SceneManager.LoadScene(levelIndex);
        }
        else
        {
            Debug.Log("Level " + levelIndex + " is locked. Complete previous levels to unlock.");
        }
    }

     public void ResetLevels()
    {
        // Lock all levels except level 1
        for (int i = 2; i <= 5; i++)
        {
            PlayerPrefs.SetInt("Level" + i + "Unlocked", 0);
            UpdateButtonState(GetButtonByIndex(i), i);
        }

        PlayerPrefs.Save();
    }

    private Button GetButtonByIndex(int index)
    {
        switch (index)
        {
            case 1:
                return level1Button;
            case 2:
                return level2Button;
            case 3:
                return level3Button;
            case 4:
                return level4Button;
            case 5:
                return level5Button;
            default:
                return null;
        }
    }
}