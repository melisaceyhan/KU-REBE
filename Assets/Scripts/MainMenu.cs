using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
public class MainMenu : MonoBehaviour {

    public RawImage background;

    IEnumerator ChangeBackground()
    {
        yield return new WaitForSeconds(1);
        background.color = new Color(255, 255, 255, 255);
    }

    void Start()
    {
        StartCoroutine(ChangeBackground());
    }

    public void GoToScene(string sceneName) 
    {
        SceneManager.LoadScene(sceneName);
    }

    public void leaderboardScene()
    {
        SceneManager.LoadScene("Leaderboard");
    }

    public void QuitApp() 
    {
        Application.Quit();
    }
}
