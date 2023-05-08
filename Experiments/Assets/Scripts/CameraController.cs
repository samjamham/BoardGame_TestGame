using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraParent[] CameraAngles = new CameraParent[2];
    private int counter = 0;

    void Start()
    {
        CameraAngles[0].enabled = true;     
        CameraAngles[1].enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (counter < CameraAngles.Length - 1)
                counter++;
            else
                counter = 0;
            for (int i = 0; i < CameraAngles.Length; i++)
            {
                CameraAngles[i].enabled = false;
            }
            CameraAngles[counter].enabled = true;
        }
    }
}
