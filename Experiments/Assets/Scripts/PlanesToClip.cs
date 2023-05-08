using UnityEngine;

[ExecuteAlways]
public class PlanesToClip: MonoBehaviour
{
    //material we pass the values to
    public Material[] Materials;
    public GameObject[] planes = new GameObject[5];
    private Clipping_Plane[] script = new Clipping_Plane[5];

    //execute every frame
    void Update()
    {
        Vector4[] planeRepresentations = new Vector4[5];
        for (int i = 0; i < planes.Length; i++)
        {
            script[i] = planes[i].GetComponent<Clipping_Plane>();
            planeRepresentations[i] = new Vector4(script[i].plane.normal.x, script[i].plane.normal.y, script[i].plane.normal.z, script[i].plane.distance);
        }
        //pass vector to shader
        for (int i = 0; i < Materials.Length; i++)
        {
            Materials[i].SetVectorArray("_Plane", planeRepresentations);
        }
    }
}