using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputmanager : MonoBehaviour
{
    private PlayerInput playerinput;
    private PlayerInput.OnfootActions onfoot;
    private playermotor motor;
    private playerlook look;

    // Start is called before the first frame update
    void Awake()
    {
        playerinput = new PlayerInput();
        onfoot = playerinput.onfoot;

        look = GetComponent<playerlook>();
        motor = GetComponent<playermotor>();

        onfoot.Jump.performed += ctx => motor.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.processMove(onfoot.movment.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.Processlock(onfoot.look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onfoot.Enable();
    }
    private void OnDisable()
    {
        onfoot.Disable();
    }
}
