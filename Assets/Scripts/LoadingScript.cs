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
    void Start()
    {

        this.GetComponent<TextMeshProUGUI>().text = "Loading..";

    }

    // Update is called once per frame
    void Update()
    {
        // this.GetComponent<TextMeshProUGUI>().text += ".";
        WaitAndPrint(Time.deltaTime);
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {

        GetComponent<TextMeshProUGUI>().text = "Loading.";
        yield return new WaitForSeconds(0.2f);

        GetComponent<TextMeshProUGUI>().text = "Loading..";
        yield return new WaitForSeconds(0.2f);


    }
}


