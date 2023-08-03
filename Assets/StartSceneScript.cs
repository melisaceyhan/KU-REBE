using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneScript : MonoBehaviour
{
    public RawImage Animation;

IEnumerator ChangeImageColor()
{
    yield return new WaitForSeconds(1f);
    Animation.color = new Color(255, 255, 255);
}
IEnumerator GoToMainMenu()
{
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene("MainMenu");
}

IEnumerator GoToStory()
{
    yield return new WaitForSeconds(5);
    SceneManager.LoadScene("Story");
}

void Start()
{
    StartCoroutine(ChangeImageColor());

    if (PlayerPrefs.GetInt("RegisterComplete") == 0)
    {
        StartCoroutine(GoToStory());
    }

    else if (PlayerPrefs.GetInt("RegisterComplete") == 1)
    {
        StartCoroutine(GoToMainMenu());
    }
}

}
