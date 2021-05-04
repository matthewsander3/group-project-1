using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTE: Attach this script to all 
public class DestroyOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 10f;

    public void OnStartHover()
    {
        //start displaying UI
        Debug.Log($"Ready to destroy {gameObject.name}");
    }
    public void OnInteract()
    {
        //Destroy, or whatever else needs to be done on click
        Destroy(gameObject);
    }
    public void OnEndHover()
    {
        //stop displaying UI
        Debug.Log($"Destroyed this object/stopped hovering");
    }

}
