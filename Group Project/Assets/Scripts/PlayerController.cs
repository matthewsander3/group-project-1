using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private Animator anim;

    private float yaw = 0.0f;
    //private float pitch = 0.0f;
    public float speedH = 10.0f;
    //public float speedV = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        if (!gameController)
            gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        /* Move Character in relation to it's direction, instead of the origin axes */
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * gameController.speed * Time.deltaTime, Space.Self);

        anim.SetFloat("walkSpeed", Input.GetAxis("Vertical") * (Input.GetKey(KeyCode.UpArrow) ? 0.5f : 1f));
        anim.SetFloat("strafeSpeed", Input.GetAxis("Horizontal"));

        if (Input.GetKey(KeyCode.E))
        {
            anim.SetTrigger("interact");
        }

        /* rotate the view with the mouse */
        yaw += speedH * Input.GetAxis("Mouse X");
        //pitch += speedV * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

    }
}
