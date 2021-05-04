using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOnInteract : MonoBehaviour, IInteractable
{
    public float MaxRange { get { return maxRange; } }

    private const float maxRange = 10f;
    public void OnEndHover()
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract()
    {
        throw new System.NotImplementedException();
    }

    public void OnStartHover()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
