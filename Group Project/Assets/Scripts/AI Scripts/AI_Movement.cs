using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Movement : MonoBehaviour
{
    private int prevPoint;
    private int destPoint;
    Animator anim;
    private NavMeshAgent nav;
    public bool shouldMove = true;
    public GameObject player;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
        prevPoint = Random.Range(1, Waypoints.points.Length);
        GoToNextPoint();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
    void Update()
    {
        if (!(this.shouldMove))
        {
            return;
        }

        Move();
    }
    void Move()
    {
        if (!nav.pathPending && nav.remainingDistance < 0.5f)
        {
            this.shouldMove = false;
            StartCoroutine(observe());
        }
    }
    IEnumerator observe()
    {
        this.shouldMove = false;
        anim.SetTrigger("WAIT1");
        int counter = 14;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            Debug.Log(counter);
        }
        anim.SetTrigger("Walk");
        GoToNextPoint();
        this.shouldMove = true;
    }

void GoToNextPoint()
    {
        destPoint = excludeRandom(1, Waypoints.points.Length, prevPoint);
        prevPoint = destPoint;
        nav.destination = Waypoints.points[destPoint].position;
        Debug.Log(nav.destination);
    }

int excludeRandom(int x, int y, int z)
{
    int num = Random.Range(x, y);
    while (num == z)
        num = Random.Range(x, y);
    return num;
}

}


