using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamLookAt : MonoBehaviour
{
    private float speedMod = 100.0f;//a speed modifier
    private Vector3 MyPos;
    [SerializeField]
    private Camera MainCam;
    [SerializeField]
    private float MyY;
    [SerializeField]
    private GameObject Player;
    public Vector3 LocalDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCam.GetComponent<CameraScript>().enabled == true)
        {
            Move();
            MyPos.y = MyY;
        }
        else
            MyPos = Player.transform.position;
        CheckIfInbounds();
        transform.position = MyPos;
    }

    private void Move()
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

    }
    private void CheckIfInbounds()
    {
        LocalDistance = transform.position - Player.transform.position;

        if (LocalDistance.x > 35.0f)
        {
            MyPos.x -= LocalDistance.x - 35.0f;
        }
        if (LocalDistance.x < -35.0f)
        {
            MyPos.x -= LocalDistance.x - -35.0f;
        }
        if (LocalDistance.z > 35.0f)
        {
            MyPos.z -= LocalDistance.z - 35.0f;
        }
        if (LocalDistance.z < -35.0f)
        {
            MyPos.z -= LocalDistance.z- -35.0f;
        }
    }
}
