using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject FollowCam;
    [SerializeField]
    private GameObject Player;
    public float Height;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform NewTransform = FollowCam.transform;

        Vector3 NewPosition = NewTransform.position;
        NewPosition.y += Height;
        NewPosition.x -= Player.transform.position.x;
        NewPosition.z -= Player.transform.position.z;
        transform.SetPositionAndRotation(NewPosition, NewTransform.rotation);

    }
}
