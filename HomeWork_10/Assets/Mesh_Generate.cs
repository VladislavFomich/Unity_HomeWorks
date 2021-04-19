using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Mesh_Generate : MonoBehaviour
{
    Mesh mesh;
    bool hitted;

    [HideInInspector]
    public float pointHight = 0.0f;
    [HideInInspector]
    public  bool isCol = false;


    void Start()
    {
        mesh = new Mesh();

        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = GenerateVertices();
        mesh.triangles = GenerateTriangles();
        mesh.RecalculateNormals();
    }

    Vector3[] GenerateVertices()
    {
        return new Vector3[]
        {
            new Vector3(0.0f,0.0f,pointHight),
            new Vector3(0.0f,0.0f,4.0f),
            new Vector3(4.0f,0.0f,pointHight),
            new Vector3(4.0f,0.0f,4.0f),         
        };
    }

    int[] GenerateTriangles()
    {
        return new int[] { 0, 1, 2, 1, 3, 2 };
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (!hitted)
        {
            hitted = true;
            isCol = true;

            foreach (ContactPoint contact in collision.contacts)
            {
               // ContactPoint contact1 = collision.contacts[0];
                ContactPoint contact2 = collision.contacts[1];
               // Vector3 point1 = contact1.point;
                Vector3 point2 = contact2.point;
                //Debug.Log(point1);
                //  Debug.Log(point2);
                if (point2.z >= 3 && point2.z < 5)
                {
                    Debug.Log("Cut Big Part");
                    pointHight = 3.1f;

                }
                else if (point2.z >= 5 && point2.z < 6)
                {
                    Debug.Log("Cut Medium Part");
                    pointHight = 2f;
                }
                else if (point2.z >= 6 && point2.z < 7)
                {
                    Debug.Log("Cut Small Part");
                    pointHight = 1.3f;
                }
                mesh = new Mesh();
                GetComponent<MeshFilter>().mesh = mesh;
                mesh.vertices = GenerateVertices();
                mesh.triangles = GenerateTriangles();
                mesh.RecalculateNormals();
            }

        }
    }
   

}
