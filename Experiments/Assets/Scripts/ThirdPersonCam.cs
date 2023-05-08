using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ThirdPersonCam : CameraParent
{
    private float targetDistance = 20.0f;

    void Start()
    {
    }

    void Update()
    {
        if (GetComponent<ThirdPersonCam>().enabled == true)
        {
            // rotate the camera
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            // move the camera position
            Vector3 addY = new Vector3(0, 12, 0);
            DestinationPos = target.transform.position + (target.transform.forward * targetDistance) + addY;
            transform.position = DestinationPos;
            transform.LookAt(target.transform.position);
        }
    }
}
