using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    public int PlayerScore;
    public Text PlayerScoretext;
    
     public void IncreaseScore()
    {
        PlayerScore += 5;
        PlayerScoretext.text = PlayerScore.ToString();
    }
}
