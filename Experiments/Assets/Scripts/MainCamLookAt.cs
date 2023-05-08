using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamLookAt : MonoBehaviour
{
    private float speedMod = 100.0f;//a speed modifier
    private Vector3 MyPos;
    [SerializeField]
    Camera MainCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCam.GetComponent<CameraScript>().enabled == true)
        {
            MyPos = transform.position;
            if (Input.GetKey("w"))
            {
                MyPos += MainCam.transform.forward * Time.deltaTime * speedMod;
            }
            if (Input.GetKey("a"))
            {
                MyPos -= MainCam.transform.right * Time.deltaTime * speedMod;
            }
            if (Input.GetKey("s"))
            {
                MyPos -= MainCam.transform.forward * Time.deltaTime * speedMod;
            }
            if (Input.GetKey("d"))
            {
                MyPos += MainCam.transform.right * Time.deltaTime * speedMod;
            }
            if (MyPos.x > 35.0f)
            {
                MyPos.x = 35.0f;
            }
            if (MyPos.x < -35.0f)
            {
                MyPos.x = -35.0f;
            }
            if (MyPos.z > 35.0f)
            {
                MyPos.z = 35.0f;
            }
            if (MyPos.z < -35.0f)
            {
                MyPos.z = -35.0f;
            }
            MyPos.y = 21.75f;
            transform.position = MyPos;
        }
    }
}
