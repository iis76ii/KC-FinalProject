using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playervelocity;
    public float speed = 5f;
    private bool isgrounded;
    public float gravity = -9.8f;
    public float jumpHeight = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = controller.isGrounded;
    }
    //receive the input from the inputmanager script and apply to the character controller
    public void processMove(Vector2 input)
    {
        Vector3 movedirction = Vector3.zero;
        movedirction.x = input.x;
        movedirction.z = input.y;
        controller.Move(transform.TransformDirection(movedirction) * speed * Time.deltaTime);
        playervelocity.y += gravity * Time.deltaTime;
        if (isgrounded && playervelocity.y < 0)
            playervelocity.y = -2f;
        controller.Move(playervelocity * Time.deltaTime);
        Debug.Log(playervelocity.y);
    }
    public void Jump()
    {
        if (isgrounded)
        {
            playervelocity.y = Mathf.Sqrt(jumpHeight * -1.5f * gravity);
        }
    }
}
