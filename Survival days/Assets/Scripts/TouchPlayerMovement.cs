using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayerMovement : MonoBehaviour 
{

    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    public bool isGrounded;

    public Transform groundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;

   
    private float halfScreenWidth;
    void Start() 
    {

        halfScreenWidth = Screen.width / 2;
    }

    // Update is called once per frame
    void Update() {
        GetTouchInput();
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

    }

    void GetTouchInput() {
        if (Input.touchCount > 0)
        {
            Debug.Log("Currently " + Input.touchCount + " fingers are touching");
        }
    }

}
