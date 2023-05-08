using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraScript : CameraParent
{  
    private float speedMod = 10.0f;//a speed modifier
    private float Distance = 70.0f;
    private float MinDistance = 5.0f, MaxDistance = 100.0f;
    public float Orbit = 0.0f;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<CameraScript>().enabled == true)
        {
            if (Input.GetMouseButton(1))
            {
                Orbit += Input.GetAxis("Mouse X") * 50 * Time.deltaTime * speedMod;
            }
            DestinationPos = target.transform.position;
            if (Input.mouseScrollDelta.y > 0)
            {
                if (Distance > MinDistance)
                {
                    Distance -= 30 * Time.deltaTime * speedMod;
                }
            }
            if (Input.mouseScrollDelta.y < 0)
            {
                if (Distance < MaxDistance)
                {
                    Distance += 30 * Time.deltaTime * speedMod;
                }

            }
            DestinationPos.x -= (Mathf.Sin((Mathf.PI / 180) * Orbit) * Distance);
            DestinationPos.z -= (Mathf.Cos((Mathf.PI / 180) * Orbit) * Distance);
            DestinationPos.y += Distance / 2;

            transform.position = DestinationPos;
            transform.LookAt(target.transform); //makes the camera look to it
        }
    }
        
}