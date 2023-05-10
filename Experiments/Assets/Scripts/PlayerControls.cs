using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private float SpeedMod = 7.0f;
    private float MaxSpeed = 10;
    private Rigidbody MyBody;
    private float DistanceToGround;

    public bool IsActive = false;

    // Start is called before the first frame update
    void Start()
    {
        MyBody = GetComponent<Rigidbody>();
        DistanceToGround = GetComponent<CapsuleCollider>().bounds.extents.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsActive)
        {
            if (Input.GetKey("w"))
            {
                MyBody.AddForce(transform.forward * -10);
            }
            if (Input.GetKey("a"))
            {
                MyBody.AddForce(transform.right * 10);
            }
            if (Input.GetKey("s"))
            {
                MyBody.AddForce(transform.forward * 10);
            }
            if (Input.GetKey("d"))
            {
                MyBody.AddForce(transform.right * -10);
            }
            if (Input.GetMouseButton(1))
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * SpeedMod, 0);
            }
            if (IsGrounded() && Input.GetKey(KeyCode.Space))
            {
                MyBody.AddForce(0, 10.0f, 0, ForceMode.Impulse);
            }
        }

        if (MyBody.velocity.magnitude > MaxSpeed)
        {
            MyBody.velocity = MyBody.velocity.normalized * MaxSpeed;
        }        
    }
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, DistanceToGround + 0.4f);
    }
}
