using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    //distance threshold
    [SerializeField] float intDistance;
    private IInteractable currTarget;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        RaycastForInteractable();

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currTarget != null)
            {
                currTarget.OnInteract();
            }
        }
    }

    private void RaycastForInteractable()
    {
        RaycastHit whatIHit;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out whatIHit, intDistance))
        {
            IInteractable interactable = whatIHit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(whatIHit.distance <= interactable.MaxRange)
                {
                    if(interactable == currTarget)
                    {
                        //keep looking at same interactable or noninteractable
                        return;
                    }
                    else if(currTarget != null)
                    {
                        //looking at new interactable after looking at old interactable
                        currTarget.OnEndHover();
                        currTarget = interactable;
                        currTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        //look at interactable from non interactable
                        currTarget = interactable;
                        currTarget.OnStartHover();
                        return;
                    }
                }
                else
                {
                    //not looking at anything in range
                    if(currTarget != null)
                    {
                        currTarget.OnEndHover();
                        currTarget = null;
                        return;
                    }
                }
            }
            else
            {
                //not looking at anything in range that's interactable
                if (currTarget != null)
                {
                    currTarget.OnEndHover();
                    currTarget = null;
                    return;
                }
            }
        }
        else
        {
            //looking at no objects at all
            if (currTarget != null)
            {
                currTarget.OnEndHover();
                currTarget = null;
                return;
            }
        }
    }
}
