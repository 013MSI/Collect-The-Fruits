using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneInstance : MonoBehaviour
{
    public List<TMP_Text> textSources;
    public TMP_Text[] textElements;
    
    // Start is called before the first frame update
    void Start()
    {
        textElements = FindObjectsOfType<TMP_Text>();

        foreach (var textObject in textSources)
        {
            if (textObject != null)
            {
                if (PlayerPrefs.GetInt("StatsState") == 0)
                {
                    textObject.gameObject.SetActive(false);
                }
            }
        }

        StatsManager.Instance.textSources = textSources;

        UpdateUIColor();
    }

    public void UpdateUIColor()
    {
        int selectedColorIndex = PlayerPrefs.GetInt("SelectedColorIndex");

        if (GameManager.Instance != null && GameManager.Instance.colors != null)
        {
            foreach (TMP_Text textElement in textElements)
            {
                Debug.Log(selectedColorIndex);
                textElement.color = GameManager.Instance.colors[selectedColorIndex];
            }
        }
    }
}
