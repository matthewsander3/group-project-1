using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //text that appears when interactable is pointed at, within a certain distance
    [SerializeField] private Text intText;
    //distance threshold for interaction text
    public float intDistance = 5.0f;

    private void Start()
    {
        //turns off text that isn't already off
        intText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //creates a ray from the camera out
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //info about raycast hits
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, intDistance))
        {
            // Optional visualization of the ray.
            Debug.DrawRay(ray.origin, ray.direction * intDistance, Color.red);

            if (hit.collider.tag == "Interactable")
            {
                //turn on the int prompt
                intText.gameObject.SetActive(true);

                /*
                //interaction on button press, fill this in later
                if(Input.GetButtonDown("InteractionButton"))
                {
                    //do something here, like animate poltergeist
                }
                */
            }
            else
            {
                intText.gameObject.SetActive(false);
            }
        }
    }
}
