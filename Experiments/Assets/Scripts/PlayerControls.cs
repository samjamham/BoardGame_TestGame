using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public GameObject Board;
    public Vector3 MyPos = new Vector3(0,0,0);
    public ThirdPersonCam myCam;

    private float SpeedMod = 7.0f;
    private Rigidbody MyBody;
    private float DistanceToGround;

    // Start is called before the first frame update
    void Start()
    {
        MyPos = transform.position - new Vector3(0, 23.4f, 0);
        MyBody = GetComponent<Rigidbody>();
        DistanceToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myCam.enabled == true)
        {
            if (Input.GetKey("w"))
            {
                MyPos += transform.forward * Time.deltaTime * SpeedMod;
            }
            if (Input.GetKey("a"))
            {
                MyPos -= transform.right * Time.deltaTime * SpeedMod;
            }
            if (Input.GetKey("s"))
            {
                MyPos -= transform.forward * Time.deltaTime * SpeedMod;
            }
            if (Input.GetKey("d"))
            {
                MyPos += transform.right * Time.deltaTime * SpeedMod;
            }
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * 110 * Time.deltaTime * SpeedMod, 0);
            }
            if (Input.GetKey(KeyCode.Space) && IsGrounded())
            {
                MyBody.AddForce(0, 10.0f, 0, ForceMode.Impulse);
            }
            Board.GetComponent<Transform>().position = MyPos;
            transform.position = new Vector3(0, transform.position.y, 0);
        }
       
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.1f);
    }
}
