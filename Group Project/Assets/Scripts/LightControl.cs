using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public float speed = 0.3f;
    void Update()
    {
        transform.Rotate(1 * speed, 0,0 );
    }
}
