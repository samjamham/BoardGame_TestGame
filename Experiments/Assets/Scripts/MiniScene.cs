using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;
using System.Linq;


public class MiniScene : MonoBehaviour
{
    private float RotationModifier = 1;
    private float angle = 0;
    private float Scalar = 1;
    private float MovementSpeed = 10;
    private TownWaypoints townWayPoints;
    private int DestinationWayPointID = 0;
    private float LocalHeight = 0;
    private float ModifidedHeight = 0;
    private float WaitTimer = 0;
    private float DistanceToWayPoint;
    // Start is called before the first frame update
    void Start()
    {
        //load all waypoints
        townWayPoints = new TownWaypoints(transform);

        // go to a random waypoint to start
        DestinationWayPointID = UnityEngine.Random.Range(0, 12);
        transform.position = townWayPoints.allWayPoints[DestinationWayPointID].WayPointPosition;
        WaitTimer += UnityEngine.Random.Range(0.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        LocalHeight = transform.position.y - ModifidedHeight;
        Debug.DrawLine(transform.position, townWayPoints.allWayPoints[DestinationWayPointID].WayPointPosition, Color.white, Time.deltaTime);
        DistanceToWayPoint = Vector3.Distance(transform.position, townWayPoints.allWayPoints[DestinationWayPointID].WayPointPosition);
        WaitTimer -= Time.deltaTime;

        if (HasReachedWayPoint())
        {
            //If on an edge waypoint teleport to another waypoint
            if (DestinationWayPointID > 4)
            {
                DestinationWayPointID = UnityEngine.Random.Range(5, 13);
                transform.position = townWayPoints.allWayPoints[DestinationWayPointID].WayPointPosition;                
            }

            int newID = UnityEngine.Random.Range(0, townWayPoints.allWayPoints[DestinationWayPointID].Connections.Count());
            DestinationWayPointID = townWayPoints.allWayPoints[DestinationWayPointID].Connections[newID].WaypointID;
            transform.LookAt(townWayPoints.allWayPoints[DestinationWayPointID].WayPointPosition);
            transform.Rotate(new Vector3(0, 180, 0));
            transform.position = new Vector3(transform.position.x, 21.0f, transform.position.z);
            LocalHeight = 0; ModifidedHeight = 0;
            WaitTimer = UnityEngine.Random.Range(0.0f, 4.0f);
        }
        if (WaitTimer < 0.0f)
        {
            FollowWaypoints();
        }
    }
    bool HasReachedWayPoint()
    {
        if (DistanceToWayPoint < 1.0f)
            return true;
        else
            return false;
    }

    void FollowWaypoints()
    {
        Scalar = ((float)Math.Pow(Scalar, 3.0f))/3;
        transform.position -= transform.forward * Time.deltaTime * Scalar * MovementSpeed;
        if (angle > 30)
        {
            RotationModifier = -1;
            Scalar = 1.5f;
        }
        if (angle < -30)
        {
            RotationModifier = 1;
            Scalar = 1.5f;
        }
        Scalar = (angle + (60 * -RotationModifier)) / (60 * -RotationModifier);
        angle += (100 * RotationModifier * Scalar * Time.deltaTime);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x , transform.localEulerAngles.y, angle); // Make the model rotate
        ModifidedHeight =  System.Math.Abs(angle) / 300;
        transform.position = new Vector3(transform.position.x, LocalHeight + ModifidedHeight, transform.position.z); //Up and down motion to keep the base form going under
    }   
}
