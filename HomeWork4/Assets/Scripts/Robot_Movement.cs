using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Movement : MonoBehaviour
{
    public float speed = 6.0f;
    public float gravity = 20.0f;
    public float jumpValue = 0.0f;
    private Vector3 moveDirecrion = Vector3.zero;

    float camSens = 0.25f;
    private Vector3 lastMouse = new Vector3(255, 255, 255);

    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirecrion = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirecrion = transform.TransformDirection(moveDirecrion);

            moveDirecrion *= speed;
            if (Input.GetButton("Jump"))
            {
                moveDirecrion.y = jumpValue;
            }
        }
        moveDirecrion.y -= gravity * Time.deltaTime;
        controller.Move(moveDirecrion * Time.deltaTime);

        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
    }
}
