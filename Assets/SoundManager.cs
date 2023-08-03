using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Image SoundOn;
    public Image SoundOff;
    private bool muted = false;

    void Start()
    {
        muted = (PlayerPrefs.GetInt("Muted") != 0);
        UpdateButtonIcon();
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
            PlayerPrefs.SetInt("Muted", 1);
        }

        else if (muted == true)
        {
            muted = false;
            AudioListener.pause = false;
            PlayerPrefs.SetInt("Muted", 0);
        }
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if (muted == false)
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
        }

        else if (muted == true)
        {
            SoundOn.enabled = false;
            SoundOff.enabled = true;
        }
    }

}
