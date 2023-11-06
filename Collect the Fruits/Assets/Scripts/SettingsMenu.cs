using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    
    // [SerializeField] private TMP_Text applesText;
    // [SerializeField] private TMP_Text bananasText;
    // [SerializeField] private TMP_Text cherriesText;
    // [SerializeField] private TMP_Text kiwisText;
    // [SerializeField] private TMP_Text melonsText;
    // [SerializeField] private TMP_Text orangesText;
    // [SerializeField] private TMP_Text pineapplesText;
    // [SerializeField] private TMP_Text strawberriesText;

    [SerializeField] private TMP_Text bgMusicButtonText;

    [SerializeField] private AudioSource bgMusic;
    // public void DisplayFruitStat()
    // {
    //     applesText.text = " " ;
    //     bananasText.text = " " ;
    //     cherriesText.text = " " ;
    //     kiwisText.text = " " ;
    //     melonsText.text = " " ;
    //     orangesText.text = " " ;
    //     pineapplesText.text = " " ;
    //     strawberriesText.text = " " ;
    // }

    public void BGMusic()
    {
        if(bgMusicButtonText.text == "O")
        {
            bgMusic.Stop();
            bgMusicButtonText.text = "X";
        }
        else if (bgMusicButtonText.text == "X")
        {
            bgMusic.Play();
            bgMusicButtonText.text = "O";
        }
        
    }
}
