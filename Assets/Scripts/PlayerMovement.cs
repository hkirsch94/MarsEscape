using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController controller;

    //movement attributes
    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    //attributes if we are on the ground or at a ladder
    public Transform groundCheck;
    public Transform LadderCheck;
    public float groundDistance = 0.4f;
    public float LadderDistance = 1f;
    public LayerMask groundMask;
    public LayerMask LadderMask;


    Vector3 velocity;
    bool isGrounded;
    bool isLadder;
    bool isSprinting;
    bool test;
    private Vector3 p1;
    private Vector3 p2;
    private RaycastHit hit;

    int ladder = 1;
    int sprint;
    int crouch;

    // Update is called once per frame

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //if we want to stop crouching, we have to check if the player has enough space to stand up
        p1 = transform.position + controller.center + Vector3.up * -controller.height * 0.5F;
        p2 = p1 + Vector3.up * controller.height;
        test = Physics.CapsuleCast(p1, p2, controller.radius, transform.up, out hit, 1);

        //Check if we are on the ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Check if we are standing next to a ladder
        isLadder = Physics.CheckSphere(LadderCheck.position, LadderDistance, LadderMask);
        //Checks if we press shift for calculating our speed
        isSprinting = Input.GetKey(KeyCode.LeftShift);
        //int values for calculation
        ladder = !isLadder ? 1 : 0;
        sprint = isSprinting ? 1 : 0;
        
        //We want to be able to let go of the ladder if we are on the ground
        if (isGrounded)
        {
            ladder = 1;

        }
        //We want to increase the velocity if we are on the ground or on a ladder
        if ((isGrounded || isLadder) && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        //Input axis WASD
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //calculate movement accordingly
        Vector3 move = transform.right * x + transform.forward * z;

        //if we are on a ladder, we want to move on Y up and down
        if (isLadder)

        {
            if (Input.GetKey(KeyCode.W))
            {
                velocity.y = 3f;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                velocity.y = -3f;
            }   
        }
        //Crouching reduces the player height
        if (Input.GetKey(KeyCode.LeftControl)) 
        {         
            this.transform.localScale = new Vector3(1f, 0.3f, 1f);
            controller.height = 0.5f;
            crouch = 1;
        }
        //Change to normal size
        else if(!(Physics.CapsuleCast(p1, p2, controller.radius, transform.up, out hit, 1f)))
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
            controller.height = 1.70f;
            crouch = 0;
        }

            


        //and finally the movement. Uses sprint and crouch as modifikator.
        //If we the buttons we get faster or slower according to the input
        controller.Move(move * speed * ladder * Mathf.Pow(2f, sprint) * Mathf.Pow(0.5f, crouch) * Time.deltaTime);
        

        //We want to be able to jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
        }
        //movement according to the velocity
        controller.Move(velocity * Time.deltaTime);
        //changes velocity.y over time according to the gravity
        velocity.y += gravity * Time.deltaTime;

    }

}
