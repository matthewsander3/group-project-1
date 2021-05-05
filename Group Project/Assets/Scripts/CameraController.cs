using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float mouseX, mouseY;
    public Transform Target, Player;

    /*
    public float camMoveSpeed = 120.0f;
    public GameObject Target;
    public GameObject CamObj;
    public GameObject PlayerObj;
    Vector3 followPos;
    public float clampAngleHigh, clampAngleLow;
    public float inSensitivity = 150.0f;
    public float camDistXToPlayer, camDistYToPlayer, camDistZToPlayer;
    private float rotX = 0.0f;
    private float rotY = 0.0f;
    */


    private void Start()
    {
        //Vector3 rot = transform.localRotation.eulerAngles;
        //rotX = rot.x;
        //rotY = rot.y;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /*
    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        mouseY = Mathf.Clamp(mouseY, -55, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);

    }
    */
    
    private void LateUpdate()
    {
        CameraControl();
    }

    
    private void CameraControl()
    {
       
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -55, 60);

        transform.LookAt(Target);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        }
        else
        {
            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
        
    }
    
}
