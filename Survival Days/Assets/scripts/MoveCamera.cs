using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform camPosision;

    private void Update()
    {
        transform.position = camPosision.position;
    }
}
