using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LoadingScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    void Start()
    {
        this.GetComponent<TextMeshProUGUI>().text = "Loading..";
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<TextMeshProUGUI>().text += ".";
    }
    private IEnumerator WaitAndPrint (float waitTime)
    {
        
        GetComponent<TextMeshProUGUI>().text += ".";
        yield return new WaitForSeconds(0.2f);

       // GetComponent<TextMeshProUGUI>().text -= ".";
        yield return new WaitForSeconds(0.2f);

        
    }
}
