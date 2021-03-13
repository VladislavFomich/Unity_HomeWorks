using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong_Script : MonoBehaviour
{
    public float speed = 0.1f;
    bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 7f)
        {
            movingRight = false;
        }
        else if (transform.position.x < -7f)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
