using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreAdderScript : MonoBehaviour
{
        public TMP_Text scoreText;
        private int ScoreDisplay = 0;
        public TMP_Text usernameText;
        public RawImage background;

    IEnumerator ChangeBackground()
    {
        yield return new WaitForSeconds(1);
        background.color = new Color(255, 255, 255, 255);
    }

    void Start()
    {
        StartCoroutine(ChangeBackground());
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

        usernameText.text = PlayerPrefs.GetString("username");
    }

    public void SendScore()
    {

        HighScores.UploadScore(PlayerPrefs.GetString("username"), ScoreDisplay);
    }

}
