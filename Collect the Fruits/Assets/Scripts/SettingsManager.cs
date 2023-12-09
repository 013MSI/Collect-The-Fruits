using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SettingsManager : MonoBehaviour
{
    public Camera gameCamera;
    public EventSystem esystem;

    public Button resumeButton;

    void Awake()
    {
        if (GameManager.Instance.pausedFromGame)
        {
            resumeButton.interactable = true;
            esystem.enabled = false;
            gameCamera.gameObject.SetActive(false);
            esystem.gameObject.SetActive(false);
            //Destroy(esystem);
        }
    }
}
