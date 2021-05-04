using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(hor, 0.0f, ver).normalized * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }

}



/*
private void Start()
{
    Cursor.visible = false;
    Cursor.lockState = CursorLockMode.Locked;
}

private void LateUpdate()
{
    CameraControl();
}

private void CameraControl()
{
    mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
    mouseY += Input.GetAxis("Mouse Y") * rotationSpeed;
    mouseY = Mathf.Clamp(mouseY, -35, 60);

    transform.LookAt(Target);

    Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    Player.rotation = Quaternion.Euler(0, mouseX, 0);
}
*/
/*
void Start()
{
if (!gameController)
    gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
}


private Vector2 GetInput()
{
//get the input vector for mouse look
Vector2 input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
return input;
}

void Update()
{
/* Move Character in relation to its direction, instead of the origin axes 
float horizontalInput = Input.GetAxis("Horizontal");
float verticalInput = Input.GetAxis("Vertical");

Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
movementDirection.Normalize();

transform.Translate(movementDirection * gameController.speed * Time.deltaTime, Space.Self);

/* rotate the view with the mouse 
//velocity of look is the current input scaled by sensitivity
Vector2 lookVelocity = GetInput() * sensitivity;

rotation += lookVelocity * Time.deltaTime;

//convert the rotation to Euler angles
transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);

}
*/

