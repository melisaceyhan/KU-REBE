using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{

    public InputField usernameInput;
    public Button registerButton;
    public static string usernameDisplay;

    const string privateCode = "zZxJO9tQ2U-bSZuPSSWmdA7kVLP3zxuECJcUampGfFxw";
    const string publicCode = "64c0f5fe8f40bb8380ddf717";
    const string webURL = "http://dreamlo.com/lb/";

    public GameObject alreadytaken;
    public GameObject bos_isim;
    public GameObject usernameTooLong;
    public RawImage background;

    List<string> usernameList = new List<string>();

    IEnumerator ChangeBackground()
    {
        yield return new WaitForSeconds(1);
        background.color = new Color(255, 255, 255, 255);
    }

    IEnumerator DatabaseUpload()
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(usernameDisplay) + "/" + 0);
        yield return www;
    }

    public void DownloadUsername()
    {
        StartCoroutine(DownloadUsernamesFromDatabse());
    }

    IEnumerator DownloadUsernamesFromDatabse()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighScores(www.text);
        }
        else 
        {
            print("Error uploading" + www.error);
        }
    }


    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < entries.Length; i ++)
        {
            string[] entryInfo = entries[i].Split("|");
            string username = entryInfo[0];
            usernameList.Add(username);    
        }
    }


    void Start()
    {
        StartCoroutine(ChangeBackground());
        DownloadUsername();
    }


    public void RegisterUser()
    {
        if (usernameList.Contains(usernameInput.text))
        {
            Debug.Log("The username is already taken!");
            alreadytaken.SetActive(true);  
            
          
        }

        else if (usernameInput.text == "")
        {
            Debug.Log("Enter a username");
            bos_isim.SetActive(true);   
        }

        else if (usernameInput.text.Length > 13)
        {
            usernameTooLong.SetActive(true);
        }

        else
        {
            usernameDisplay = usernameInput.text;
            PlayerPrefs.SetString("username", usernameDisplay);
            PlayerPrefs.SetInt("RegisterComplete", 1);
            Debug.Log("Successfully registered!");
            GoToMainMenu();
            StartCoroutine(DatabaseUpload());
        }
    }

    [ContextMenu("ChangeState")]
    public void ChangeState()
    {
        PlayerPrefs.SetInt("RegisterComplete", 0);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
