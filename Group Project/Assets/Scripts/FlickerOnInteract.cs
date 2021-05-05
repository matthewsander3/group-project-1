using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickerOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 10f;
    public int redCol, blueCol, greenCol;
    public bool flashingIn = false;
    public bool lookingAt;

    [SerializeField] private int scaredVal = 15;

    public Slider scareSlider;
    public GameObject waifu;

    [SerializeField] private GameObject interactable;

    public void OnStartHover()
    {
        //enable interact UI
        //Debug.Log("Hovered over flickerable.");
        interactable.SetActive(true);
        lookingAt = true;
        gameObject.GetComponentInParent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        StartCoroutine("OnLookFlash");
        //throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        //make the selected light flicker
        StartCoroutine("Flicker");

        waifu = GameObject.FindWithTag("Enemy");
        float distFromWaifu = Vector3.Distance(waifu.transform.position, gameObject.transform.position);
        if (distFromWaifu <= 10)
        {
            GameController.cost -= scaredVal;
            Debug.Log("SCARED");
            scareSlider.value += scaredVal;
        }
        //throw new System.NotImplementedException();
    }

    public void OnEndHover()
    {
        //disable interact UI
        //Debug.Log("Not hovered over flickerable.");
        interactable.SetActive(false);
        lookingAt = false;
        StopCoroutine("OnLookFlash");
        gameObject.GetComponentInParent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        //throw new System.NotImplementedException();
    }




    IEnumerator OnLookFlash()
    {
        while(lookingAt == true)
        {
            yield return new WaitForSeconds(0.05f);
            if(flashingIn)
            {
                if(blueCol <= 30)
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

            if(!flashingIn)
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
            gameObject.GetComponentInParent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }

    IEnumerator Flicker()
    {
        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Light>().enabled = true;

        yield return new WaitForSeconds(2);

        for (int i = 0; i < 3; i++)
        {
            gameObject.GetComponent<Light>().enabled = false;
            yield return new WaitForSeconds(0.1f);
            gameObject.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        gameObject.GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Light>().enabled = false;
    }
}
