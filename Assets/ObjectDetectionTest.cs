using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetectionTest : MonoBehaviour
{
    public void ChangeTransform() 
    {
        transform.localEulerAngles = new Vector3(0,27,34);
    }

    public void ResetTransform()
    {
        transform.localEulerAngles = new Vector3(0, 0, 0);
    }
}
