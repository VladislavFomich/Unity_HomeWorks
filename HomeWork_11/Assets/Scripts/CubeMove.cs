using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public Vector3 pointMove;
    public float speed;

    bool inPosition = false;
    Vector3 startPos;

    void Start()
    {
         startPos = new Vector3(transform.position.x, transform.position.y,transform.position.z);
    }


    void Update()
    {
        if (transform.position == startPos)
            inPosition = false;
       
        else if (transform.position == pointMove)
            inPosition = true;

        if (inPosition == false)
            transform.position = Vector3.MoveTowards(transform.position, pointMove, speed * Time.deltaTime);
        
        else if (inPosition == true)
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
    }
}
