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
    bool isHitted = false;
    bool stopGenerateMesh = false;

    Vector3[] GenerateVerticesSecond()
    {
        return new Vector3[]
        {
            new Vector3(0.0f,0.0f,0.0f),
            new Vector3(0.0f,0.0f,hightSecond),
            new Vector3(4.0f,0.0f,0.0f),
            new Vector3(4.0f,0.0f,hightSecond),

             new Vector3(0.0f,-0.2f,0.0f),
            new Vector3(0.0f,-0.2f,hightSecond),
            new Vector3(4.0f,-0.2f,0.0f),
            new Vector3(4.0f,-0.2f,hightSecond),
        };
    }

    int[] GenerateTrianglesSecond()
    {
        return new int[] { 0, 1, 2, 1, 3, 2, 5, 4, 7, 4, 6, 7, 4, 0, 6, 0, 2, 6, 5, 1, 4, 1, 0, 4, 7, 3, 5, 3, 1, 5, 6, 2, 7, 2, 3, 7 };
    }

    void Update()
    {

        float zPosition = firstPart.transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, zPosition);
        if (firstHight.hitted == true)
            isHitted = true;

        if (isHitted == true && stopGenerateMesh == false )
        {
            hightSecond = firstHight.pointHight;
            SecondPartGenerate();
            isHitted = false;
            stopGenerateMesh = true;
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

        gameObject.AddComponent<BoxCollider>();
        BoxCollider meshCOl = GetComponent<BoxCollider>();
        gameObject.AddComponent<Rigidbody>();
    }
   
}
