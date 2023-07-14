using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{
    public UAVPathfinding pathfinding;
    public TextMesh txt;


    void Start()
    {
        txt.text = gameObject.name + "\n" + "X : " + transform.position.x + "  Y : " + transform.position.y + "  Z : " + transform.position.z;
        pathfinding = GameObject.Find("Model").GetComponent<UAVPathfinding>();
        if (pathfinding != null) 
        {
            pathfinding.Target = gameObject;
        }
    }

   
}
