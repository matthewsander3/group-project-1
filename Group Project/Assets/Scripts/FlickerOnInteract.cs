using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 10f;

    public void OnStartHover()
    {
        //enable interact UI
        Debug.Log("Hovered over flickerable.");
        //throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        //make the selected light flicker
        StartCoroutine("Flicker");
        //throw new System.NotImplementedException();
    }

    public void OnEndHover()
    {
        //disable interact UI
        Debug.Log("Not hovered over flickerable.");
        //throw new System.NotImplementedException();
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
