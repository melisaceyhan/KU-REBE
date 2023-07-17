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
        PlayerScoretext.text = PlayerScore.ToString();
    }

    public void IncreaseScore2()
    {
        PlayerScore += 50;
        PlayerScoretext.text = PlayerScore.ToString();
    }

    public void IncreaseScore3()
    {
        PlayerScore += 100;
        PlayerScoretext.text = PlayerScore.ToString();
    }

    public void IncreaseScore4()
    {
        PlayerScore += 200;
        PlayerScoretext.text = PlayerScore.ToString();
    }
}
