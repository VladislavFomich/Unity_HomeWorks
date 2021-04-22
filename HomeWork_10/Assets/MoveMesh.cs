using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMesh : MonoBehaviour
{
    public float speed = 1f;
 
    void Update()
    {
        Move();
        StopMesh();
    }

   void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    void StopMesh()
    {
        if (Input.GetMouseButtonDown(0))
        {
            speed = 0;
            gameObject.AddComponent<BoxCollider>();
            gameObject.AddComponent<Rigidbody>();
            BoxCollider meshCOl = GetComponent<BoxCollider>();
        }
    }
}
