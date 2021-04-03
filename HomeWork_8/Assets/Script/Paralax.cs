using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public float lastPositon = -9f;
    public float speed = 0f;
    private void Start()
    {
     
    }

    void Update()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);

        if (transform.position.x <= lastPositon)
        {
            var currentPos = transform.position;
            currentPos.x -= lastPositon;
            transform.position = currentPos;
        }
    }
}
