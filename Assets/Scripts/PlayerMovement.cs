using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 6f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

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
        p1 = transform.position + controller.center + Vector3.up * -controller.height * 0.5F;
        p2 = p1 + Vector3.up * controller.height;
        test = Physics.CapsuleCast(p1, p2, controller.radius, transform.up, out hit, 1);
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        isLadder = Physics.CheckSphere(LadderCheck.position, LadderDistance, LadderMask);

        isSprinting = Input.GetKey(KeyCode.LeftShift);
        
        ladder = !isLadder ? 1 : 0;
        sprint = isSprinting ? 1 : 0;
        

        if (isGrounded)
        {
            ladder = 1;

        }
        if ((isGrounded || isLadder) && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

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
        if (Input.GetKey(KeyCode.LeftControl)) 
        {         
            this.transform.localScale = new Vector3(1f, 0.3f, 1f);
            controller.height = 0.5f;
            crouch = 1;
        }
        else if(!(Physics.CapsuleCast(p1, p2, controller.radius, transform.up, out hit, 1f)))
        {
            this.transform.localScale = new Vector3(1f, 1f, 1f);
            controller.height = 1.70f;
            crouch = 0;
        }

            



        controller.Move(move * speed * ladder * Mathf.Pow(2f, sprint) * Mathf.Pow(0.5f, crouch) * Time.deltaTime);
        


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f *gravity);
        }

        controller.Move(velocity * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

    }

}
