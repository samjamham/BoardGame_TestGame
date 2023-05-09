using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject FollowCam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform NewTransform = FollowCam.transform;

        Vector3 NewPosition = NewTransform.position;
        NewPosition.y -= 1000;
        transform.SetPositionAndRotation(NewPosition, NewTransform.rotation);

    }
}
