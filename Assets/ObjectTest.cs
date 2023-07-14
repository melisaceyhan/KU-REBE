using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectTest : MonoBehaviour
{
    public GameObject obj;
    public Text txt;


    public void ShowName() 
    {
        txt.text = obj.name;
    }


    public void Createnewobject() 
    {
        Invoke("creatationanobject",3);
    }

    void creatationanobject() 
    {
        GameObject Nobj = Instantiate(obj);
        Nobj.transform.parent = obj.transform.parent;
        Nobj.transform.localPosition = new Vector3(2,0,3);
        Nobj.transform.localEulerAngles = new Vector3(0, 25, 0);
        txt.text = "Mission is done !";

    }
}
