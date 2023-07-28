using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAdderScript : MonoBehaviour
{

    void Start()
    {
        SendScore();
    }

    public void SendScore()
    {

        HighScores.UploadScore("ozan", 100);
    }

}
