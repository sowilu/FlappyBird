using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform birb;

    void Update()
    {
        var newPos = transform.position;
        newPos.x = birb.position.x;

        transform.position = newPos;
    }
}
