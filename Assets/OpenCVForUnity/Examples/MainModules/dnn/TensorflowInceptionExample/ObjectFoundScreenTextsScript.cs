using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFoundScreenTextsScript : MonoBehaviour
{
    public Text recentScoreText;
    public ScoreManagerScript scoreManagerScript;

    [ContextMenu("PrintRecentScore")]
    public void PrintRecentScore()
    {
        recentScoreText.text = "Your current score:\n" + scoreManagerScript.PlayerScore.ToString();
    }

}
