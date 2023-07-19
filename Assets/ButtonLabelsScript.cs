using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLabelsScript : MonoBehaviour
{
    public OpenCVForUnityExample.TensorflowInceptionWebCamTextureExample tensorflowInceptionWebCamTextureExample;

    public Text button1;
    public Text button2;
    public Text button3;
    public Text button4;
    public Text button5;
    public Text button6;
    public Text button7;

    [ContextMenu("RenewButtonNames")]
    public void RenewButtonLabels()
    {
        button1.text = tensorflowInceptionWebCamTextureExample.Object1;
        button2.text = tensorflowInceptionWebCamTextureExample.Object2;
        button3.text = tensorflowInceptionWebCamTextureExample.Object3;
        button4.text = tensorflowInceptionWebCamTextureExample.Object4;
        button5.text = tensorflowInceptionWebCamTextureExample.Object5;
        button6.text = tensorflowInceptionWebCamTextureExample.Object6;
        button7.text = tensorflowInceptionWebCamTextureExample.Object7;
    }

    void Start()
    {
        RenewButtonLabels();
    }
}
