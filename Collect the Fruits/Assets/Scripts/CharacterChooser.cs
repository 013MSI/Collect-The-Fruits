using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChooser : MonoBehaviour
{

    void Start()
    {
        // Load the chosen animation override from PlayerPrefs
        string savedAnimationOverride = PlayerPrefs.GetString("AnimationOverrideKey");
    }

    public void ChooseAnimationOverride(int option)
    {
        switch (option)
        {
            case 1:
                PlayerPrefs.SetString("AnimationOverrideKey", "pinkMan");
                break;
            case 2:
                PlayerPrefs.SetString("AnimationOverrideKey", "maskDude");
                break;
            case 3:
                PlayerPrefs.SetString("AnimationOverrideKey", "virtualGuy");
                break;
            default:
                PlayerPrefs.SetString("AnimationOverrideKey", string.Empty);
                break;
        }

        PlayerPrefs.Save();
    }

    // defualt - ninja frog
    public void OnClickButton0()
    {
        ChooseAnimationOverride(0);
        Debug.Log("Ninga Frog Chosen - " + PlayerPrefs.GetString("AnimationOverrideKey") + " - 0");
    }

    // pink man
    public void OnClickButton1()
    {
        ChooseAnimationOverride(1);
        Debug.Log("Pink Man Chosen - " + PlayerPrefs.GetString("AnimationOverrideKey") + " - 1");
    }

    // mask dude
    public void OnClickButton2()
    {
        ChooseAnimationOverride(2);
        Debug.Log("Mask Dude Chosen - " + PlayerPrefs.GetString("AnimationOverrideKey") + " - 2");
    }

    // virtual guy
    public void OnClickButton3()
    {
        ChooseAnimationOverride(3);
        Debug.Log("Virtual Guy Chosen - " + PlayerPrefs.GetString("AnimationOverrideKey") + " - 3");
    }
}
