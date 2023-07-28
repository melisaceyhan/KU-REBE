using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAdderScript : MonoBehaviour
{
        public TMP_Text scoreText;
        private int ScoreDisplay = 0;

    void Start()
    {
        if (ScoreManagerScript.PlayerScore < PlayerPrefs.GetInt("PlayerScore"))
        {
            ScoreDisplay = PlayerPrefs.GetInt("PlayerScore");
        }

        else if (ScoreManagerScript.PlayerScore >= PlayerPrefs.GetInt("PlayerScore"))
        {
            ScoreDisplay = ScoreManagerScript.PlayerScore;
        }

        scoreText.text = ScoreDisplay.ToString();

        SendScore();
    }

    public void SendScore()
    {

        HighScores.UploadScore("ozank", ScoreDisplay);
    }

}
