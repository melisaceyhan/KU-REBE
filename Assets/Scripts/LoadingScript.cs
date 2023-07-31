using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    private bool coroutineNotInLoop;
    void Start()
    {

        this.GetComponent<TextMeshProUGUI>().text = "Loading.";
        StartCoroutine(WaitAndPrint());
        StartCoroutine(ChangeScene());

    }

    // Update is called once per frame


    private IEnumerator WaitAndPrint()
    {

        while (coroutineNotInLoop == false)
        {
            GetComponent<TextMeshProUGUI>().text = "Loading..";
            yield return new WaitForSeconds(1);

            GetComponent<TextMeshProUGUI>().text = "Loading...";
            yield return new WaitForSeconds(1);

            GetComponent<TextMeshProUGUI>().text = "Loading.";
            yield return new WaitForSeconds(1);
        }

    }

    private IEnumerator ChangeScene()
    {

        yield return new WaitForSeconds(6);
        coroutineNotInLoop = true;
        SceneManager.LoadScene(sceneName);

    }

}


