using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingToObject : MonoBehaviour
{
    public static string selectedObj;
    public static string internalObj;
    public RaycastHit theObj;

    void Update()
    {
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out theObj))
        {
            selectedObj = theObj.transform.gameObject.name;
            internalObj = theObj.transform.gameObject.name;
        }
    }
}
