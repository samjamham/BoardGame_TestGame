﻿using UnityEngine;

[ExecuteAlways]
public class Clipping_Plane : MonoBehaviour
{
    //material we pass the values to
    public int ID;
    public Plane plane = new Plane();

    //execute every frame
    void Update()
    {
        //create plane
        plane = new Plane(transform.up, transform.position);
        //transfer values from plane to vector4
        //Vector4 planeRepresentation = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
        //pass vector to shader
        //mat.SetVector("_Plane", planeRepresentation);
    }
}