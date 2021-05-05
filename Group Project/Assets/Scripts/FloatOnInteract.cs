using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 10f;

    private float height;
    private float speed = 5f;
<<<<<<< HEAD
<<<<<<< HEAD
    Vector3 curPos ;
=======
    Vector3 curPos;
>>>>>>> Matt3
=======
    Vector3 curPos;
>>>>>>> origin/Test
    Vector3 tempPos;
    Vector3 origPos;

    GameController gc;
    private int cost = 15;
    private int scaredVal = 20;
    bool floating = false;
    bool ending = false;
    bool scared = false;
    int i = 0;

    public int redCol, blueCol, greenCol;
    public bool flashingIn = false;
    public bool lookingAt;

    [SerializeField] private GameObject interactable;

    public void Start()
    {
        curPos = transform.position;
        origPos = curPos;
        //interactable = GetComponent<GameController>().interactable; 
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
<<<<<<< HEAD
<<<<<<< HEAD
                    
=======

>>>>>>> Matt3
=======

>>>>>>> origin/Test
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
<<<<<<< HEAD
<<<<<<< HEAD
   }
    public void OnStartHover()
    {
        Debug.Log("yeet ");
      
=======
=======
    }

    IEnumerator OnLookFlash()
    {
        while (lookingAt == true)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn)
            {
                if (blueCol <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    blueCol -= 25;
                    redCol -= 25;
                    //greenCol -= 25;
                }
            }

            if (!flashingIn)
            {
                if (blueCol >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    blueCol += 25;
                    redCol += 25;
                    //greenCol += 25;
                }
            }
            gameObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
>>>>>>> origin/Test
    }

    public void OnStartHover()
    {
        Debug.Log("yeet ");
        lookingAt = true;
        interactable.SetActive(true);
        gameObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        StartCoroutine("OnLookFlash");

<<<<<<< HEAD
>>>>>>> Matt3
=======
>>>>>>> origin/Test
    }
    public void OnInteract()
    {
        StartCoroutine("Float");
        GameController.cost = cost;
        //didScared()           call this function to see if you scared the person and if yes then change scared bool to true
        if (scared)             //
        {
            Debug.Log("In range!");
            GameController.scareVal = scaredVal;
            scared = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        scared = true;
    }

    public void didScare()
    {
        //if()
    }

    IEnumerator Float()
    {
<<<<<<< HEAD
<<<<<<< HEAD
        
=======

>>>>>>> Matt3
=======

>>>>>>> origin/Test
        floating = true;
        yield return new WaitForSeconds(3);
        ending = true;
        yield return new WaitForSeconds(1);
        floating = false;
<<<<<<< HEAD
<<<<<<< HEAD
      //  transform.position = origPos;
=======
        //  transform.position = origPos;
>>>>>>> Matt3
=======
        //  transform.position = origPos;
>>>>>>> origin/Test
    }
    public void OnEndHover()
    {
        Debug.Log("going out");
<<<<<<< HEAD
<<<<<<< HEAD
        
=======

>>>>>>> Matt3
=======
        interactable.SetActive(false);
        lookingAt = false;
        StopCoroutine("OnLookFlash");
        gameObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
>>>>>>> origin/Test
    }


}



