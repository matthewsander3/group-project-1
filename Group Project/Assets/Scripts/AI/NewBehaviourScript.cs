using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAI : MonoBehaviour
{
    public GameObject destination1;
    NavMeshAgent theAgent;
    void Start()
    {
        theAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        theAgent.SetDestination(destination1.transform.position);
    }
}
