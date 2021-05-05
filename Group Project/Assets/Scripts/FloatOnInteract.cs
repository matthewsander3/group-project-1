using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 10f;

    private float height;
    private float speed = 5f;
    Vector3 curPos;
    Vector3 tempPos;
    Vector3 origPos;

    GameController gc;
    private int cost = 10;
    bool floating = false;
    bool ending = false;
    int i = 0;

    public void Start()
    {
        curPos = transform.position;
        origPos = curPos;
    }

    public void Update()
    {
        if (floating)
        {
            if (ending)
            {
                if ((1 + Mathf.Sin(Time.time * Mathf.PI)) * 0.5f < 0.5)
                {
                    Debug.Log("Ending the loop");
                    ending = false;

                }
            }
            else
            {
                tempPos = curPos;
                tempPos.y += (1 + Mathf.Sin(Time.time * Mathf.PI)) * 0.5f;
                //Debug.Log((1 + Mathf.Sin(Time.time * Mathf.PI)) * 0.5f);
                transform.position = tempPos;
            }
        }
    }
    public void OnStartHover()
    {
        Debug.Log("yeet ");

    }
    public void OnInteract()
    {
        StartCoroutine("Float");
        GameController.cost = cost;
    }

    IEnumerator Float()
    {

        floating = true;
        yield return new WaitForSeconds(3);
        ending = true;
        yield return new WaitForSeconds(1);
        floating = false;
        //  transform.position = origPos;
    }
    public void OnEndHover()
    {
        Debug.Log("going out");

    }


}



