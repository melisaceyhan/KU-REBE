using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectFoundScreenTextsScript : MonoBehaviour
{
    public Text recentScoreText;

    [ContextMenu("PrintRecentScore")]
    public void PrintRecentScore()
    {
        recentScoreText.text = "Your current score:\n" + ScoreManagerScript.PlayerScore.ToString();
    }

}
