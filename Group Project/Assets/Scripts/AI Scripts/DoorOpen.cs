using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Waifu")
        {
            transform.Rotate(0, 90, 0, Space.Self);
            Debug.Log("HIT");
            audioSource.Play(0);
        }
    }
    void OnCollisionExit(Collision col)
    {

        Debug.Log("UNHIT");
        OpenDoor();
        transform.Rotate(0, -90, 0, Space.Self);
    }

    IEnumerator OpenDoor()
    {
        int counter = 1;
        while (counter > 0)
        {
            yield return new WaitForSeconds(.5f);
            counter--;
            Debug.Log(counter);
        }
        //transform.Rotate(0, -90, 0, Space.Self);
    }
}
