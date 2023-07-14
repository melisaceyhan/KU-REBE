using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UAVPathfinding : MonoBehaviour
{
    public GameObject Target;
    public float movementspeed;

    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector3.Lerp(transform.position, Target.transform.position, movementspeed);
            transform.LookAt(Target.transform.position);
        } 
    }
}
