using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownWaypoints
{
    public AllWaypoints[]  allWayPoints = new AllWaypoints[13];

    public TownWaypoints(Transform aTransform)
    {
        ConnectWaypoints(aTransform);
    }

    private void ConnectWaypoints(Transform aTransform)
    {
        for (int i = 0; i < allWayPoints.Length; i++)
        {
            allWayPoints[i] = new AllWaypoints();
            allWayPoints[i].Connections = new List<AllWaypoints>();
            allWayPoints[i].WaypointID = i;
        }
        //Locations in town Waypoints 
        allWayPoints[0].WayPointPosition = new Vector3(0f, aTransform.position.y, 0f); //Centre
        allWayPoints[1].WayPointPosition = new Vector3(-15.0f, aTransform.position.y, 15.0f); //Shop
        allWayPoints[2].WayPointPosition = new Vector3(15.0f, aTransform.position.y, 15.0f); //QuestBoard
        allWayPoints[3].WayPointPosition = new Vector3(15.0f, aTransform.position.y, -15.0f); //Recruit
        allWayPoints[4].WayPointPosition = new Vector3(-15.0f, aTransform.position.y, -15.0f); //LevelUp

        //out of town waypoints

        //Back left
        allWayPoints[5].WayPointPosition = new Vector3(-5f, aTransform.position.y, 2.7f);
        allWayPoints[6].WayPointPosition = new Vector3(-2.7f, aTransform.position.y, 5f);
        //Back right
        allWayPoints[7].WayPointPosition = new Vector3(2.7f, aTransform.position.y, 5f);
        allWayPoints[8].WayPointPosition = new Vector3(5f, aTransform.position.y, 2.7f);
        //Front right
        allWayPoints[9].WayPointPosition = new Vector3(5f, aTransform.position.y, -2.7f);
        allWayPoints[10].WayPointPosition = new Vector3(2.7f, aTransform.position.y, -5f);
        //Front left
        allWayPoints[11].WayPointPosition = new Vector3(-2.7f, aTransform.position.y, -5f);
        allWayPoints[12].WayPointPosition = new Vector3(-5f, aTransform.position.y, -2.7f);

        //Hardcoding conections for each waypoint 
        allWayPoints[0].Connections.Add(allWayPoints[1]);
        allWayPoints[0].Connections.Add(allWayPoints[2]);
        allWayPoints[0].Connections.Add(allWayPoints[3]);
        allWayPoints[0].Connections.Add(allWayPoints[4]);

        allWayPoints[1].Connections.Add(allWayPoints[0]);
        allWayPoints[1].Connections.Add(allWayPoints[2]);
        allWayPoints[1].Connections.Add(allWayPoints[4]);
        allWayPoints[1].Connections.Add(allWayPoints[5]);
        allWayPoints[1].Connections.Add(allWayPoints[6]);

        allWayPoints[2].Connections.Add(allWayPoints[0]);
        allWayPoints[2].Connections.Add(allWayPoints[1]);
        allWayPoints[2].Connections.Add(allWayPoints[3]);
        allWayPoints[2].Connections.Add(allWayPoints[7]);
        allWayPoints[2].Connections.Add(allWayPoints[8]);

        allWayPoints[3].Connections.Add(allWayPoints[0]);
        allWayPoints[3].Connections.Add(allWayPoints[2]);
        allWayPoints[3].Connections.Add(allWayPoints[4]);
        allWayPoints[3].Connections.Add(allWayPoints[9]);
        allWayPoints[3].Connections.Add(allWayPoints[10]);

        allWayPoints[4].Connections.Add(allWayPoints[0]);
        allWayPoints[4].Connections.Add(allWayPoints[1]);
        allWayPoints[4].Connections.Add(allWayPoints[3]);
        allWayPoints[4].Connections.Add(allWayPoints[11]);
        allWayPoints[4].Connections.Add(allWayPoints[12]);

        allWayPoints[5].Connections.Add(allWayPoints[1]);
        allWayPoints[6].Connections.Add(allWayPoints[1]);

        allWayPoints[7].Connections.Add(allWayPoints[2]);
        allWayPoints[8].Connections.Add(allWayPoints[2]);

        allWayPoints[9].Connections.Add(allWayPoints[3]);
        allWayPoints[10].Connections.Add(allWayPoints[3]);

        allWayPoints[11].Connections.Add(allWayPoints[4]);
        allWayPoints[12].Connections.Add(allWayPoints[4]);
    }

    public struct AllWaypoints
    {
        public int WaypointID;
        public Vector3 WayPointPosition;
        public List<AllWaypoints> Connections;
    }

}
