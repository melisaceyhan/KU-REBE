using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAnimation : MonoBehaviour
{
    [SerializeField] Vector3 _targetPosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) MoveToExample();
    }

    void MoveToExample()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("position", _targetPosition, "time", 2.5f, "easetype", iTween.EaseType.easeInOutSine));

    }
}
