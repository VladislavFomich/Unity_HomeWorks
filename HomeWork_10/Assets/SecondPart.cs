using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class SecondPart : MonoBehaviour
{
    public GameObject firstPart;
    public Mesh_Generate firstHight;
    Mesh mesh2;

    float hightSecond = 0.0f;

    Vector3[] GenerateVerticesSecond()
    {
        return new Vector3[]
        {
            new Vector3(0.0f,0.0f,0.0f),
            new Vector3(0.0f,0.0f,hightSecond),
            new Vector3(4.0f,0.0f,0.0f),
            new Vector3(4.0f,0.0f,hightSecond),
        };
    }

    int[] GenerateTrianglesSecond()
    {
        return new int[] { 0, 1, 2, 1, 3, 2 };
    }

    // Update is called once per frame
    void Update()
    {

        float zPosition = firstPart.transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
        if (firstHight.isCol == true)
        {
            hightSecond = firstHight.pointHight;
            SecondPartGenerate();
            firstHight.isCol = false;
            /*
            if (firstHight.pointHight == 3.1f)
            {
                firstHight.isCol = false;
                hightSecond =3.1f;
                SecondPartGenerate();
            }
            else if (firstHight.pointHight == 2f)
            {
                firstHight.isCol = false;
                hightSecond = 2f;
                SecondPartGenerate();
            }

            else if (firstHight.pointHight == 1.3f)
            {
                firstHight.isCol = false;
                hightSecond = 1.0f;
                SecondPartGenerate();
            } */                   
        }          
    }   

    void SecondPartGenerate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        mesh2 = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh2;
        mesh2.vertices = GenerateVerticesSecond();
        mesh2.triangles = GenerateTrianglesSecond();
        mesh2.RecalculateNormals();

        gameObject.AddComponent<MeshCollider>();
        MeshCollider meshCOl = GetComponent<MeshCollider>();
        meshCOl.convex = true;
        gameObject.AddComponent<Rigidbody>();
    }
   
}
