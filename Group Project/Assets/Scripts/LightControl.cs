using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public int speed = 150;
    void Update()
    {
        transform.Rotate(Time.deltaTime * speed, 0,0)  ;
    }
}
