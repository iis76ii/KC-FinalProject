using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;
    public float maxhealth = 100f;
    public float chipspeed = 2f;
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
        updatehealthUI();

    }
    public void updatehealthUI()
    {
        Debug.Log(health);
        float fillf = fronthealthbar.fillAmount;
        float fillb = backhealthbar.fillAmount;
        float hFraction = health / maxhealth;
        if (fillb > hFraction)
        {
            fronthealthbar.fillAmount = hFraction;
            backhealthbar.color = Color.red;
            lerpTimer = Time.deltaTime;
            float presentComplete = lerpTimer / chipspeed;
            presentComplete = presentComplete * presentComplete;
            backhealthbar.fillAmount = Mathf.Lerp(fillb, hFraction, presentComplete);
        }
        if (fillf < hFraction)
        {
            backhealthbar.color = Color.green;
            backhealthbar.fillAmount = hFraction;
            lerpTimer = Time.deltaTime;
            float presentComplete = lerpTimer / chipspeed;
            presentComplete = presentComplete * presentComplete;
            fronthealthbar.fillAmount = Mathf.Lerp(fillf, backhealthbar.fillAmount, presentComplete);
        }
    }

    public void takedamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }
    public void restorhealth (float heal)
    {
        health += heal;
        lerpTimer = 0f;
    }
}
