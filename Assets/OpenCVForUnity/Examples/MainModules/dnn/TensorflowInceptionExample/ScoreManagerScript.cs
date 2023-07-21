using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public int PlayerScore;
    public Text PlayerScoretext;


    public void IncreaseScore1()
    {
        PlayerScore += 30;
        PlayerPrefs.SetInt("PlayerScore", PlayerScore);
        PlayerScoretext.text = PlayerScore.ToString();
    }

    public void IncreaseScore2()
    {
        PlayerScore += 50;
        PlayerPrefs.SetInt("PlayerScore", PlayerScore);
        PlayerScoretext.text = PlayerScore.ToString();
    }

    public void IncreaseScore3()
    {
        PlayerScore += 100;
        PlayerPrefs.SetInt("PlayerScore", PlayerScore);
        PlayerScoretext.text = PlayerScore.ToString();
    }

    public void IncreaseScore4()
    {
        PlayerScore += 200;
        PlayerPrefs.SetInt("PlayerScore", PlayerScore);
        PlayerScoretext.text = PlayerScore.ToString();
    }

    void Start()
    {
        PlayerScore = PlayerPrefs.GetInt("PlayerScore");
        PlayerScoretext.text = PlayerScore.ToString();
    }

    [ContextMenu("ResetPlayerScore")]
    public void ResetPlayerScore()
    {
        PlayerScore = 0;
        PlayerPrefs.SetInt("PlayerScore", PlayerScore);
        PlayerScoretext.text = PlayerScore.ToString();
    }

}
