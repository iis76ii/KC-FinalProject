using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerlook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;

    private float xSenstivity = 30f;
    private float ySenstivity = 30f;
    
    public void Processlock(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;
        //calculate camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySenstivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //apply this to our camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        //rotate the player left and rigth 
        transform.Rotate(Vector3.up *(mouseX * Time.deltaTime) * xSenstivity);
    }
}
