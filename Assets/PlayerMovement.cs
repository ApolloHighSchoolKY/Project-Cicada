using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;

    public float walkSpeed = 4f;
    public float sprintSpeed = 8f;
    public float walkJumpSpeed = 8.0f;
    public float sprintJumpSpeed = 12.0f;

    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float turner;
    private float looker;
    public float sensitivity;

    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        //Checks to see if player is pushisng "shift" to enable sprint
        // you can use the ternary operator in this case
        speed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : walkSpeed; //changes walk speed
        jumpSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintJumpSpeed : walkJumpSpeed; //changes jump speed
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CharacterController controller = GetComponent<CharacterController>();
        // is the controller on the ground?
        if (controller.isGrounded)
        {
            //Feed moveDirection with input.
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            //Multiply it by speed.
            moveDirection *= speed;
            //Jumping
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        turner = Input.GetAxis("Mouse X") * sensitivity;
        looker = -Input.GetAxis("Mouse Y") * sensitivity;
        if (turner != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(0, turner, 0);
        }
        if (looker != 0)
        {
            //Code for action on mouse moving right
            transform.eulerAngles += new Vector3(looker, 0, 0);
        }
        //Applying gravity to the controller
        moveDirection.y -= gravity * Time.deltaTime;
        //Making the character move
        controller.Move(moveDirection * Time.deltaTime);
    }
}
