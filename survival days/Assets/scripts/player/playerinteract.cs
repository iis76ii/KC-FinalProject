using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerinteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private inputmanager inputmanager;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<playerlook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputmanager = GetComponent<inputmanager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.updatetexet(string.Empty);
        // create a ray at the center of the camera ,shooting outwards .
        Ray ray = new Ray (cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitinfo; // variable to store our collision information
       if (Physics.Raycast(ray, out hitinfo, distance, mask))
        {
            if (hitinfo.collider.GetComponent<interactable>() != null)
            {
                interactable interactable = hitinfo.collider.GetComponent<interactable>();
                playerUI.updatetexet(interactable.promptmassege);
                if (inputmanager.onfoot.interact.triggered)
                {
                    interactable.baseinteract();
                }
            }
        }
    }
}
