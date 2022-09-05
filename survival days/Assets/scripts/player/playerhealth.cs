using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxhealth = 100f;
    public float chipSpeed = 2f;
    public Image fronthealthbar;
    public Image backhealthbar;


    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxhealth);
        updatehealthui();
    }
    public void updatehealthui()
    {
        Debug.Log(health);
    }
}
