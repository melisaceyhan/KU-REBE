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
        UpdateButtonIcon();
    }

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }

        else if (muted == true)
        {
            muted = false;
            AudioListener.pause = false;
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
