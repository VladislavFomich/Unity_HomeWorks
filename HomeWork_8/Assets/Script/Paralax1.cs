using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax1 : MonoBehaviour
{
    private float length, startpos;
    public GameObject cam;
    public float paralaxEffect;
    //float speed = 1;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void  Update()
    {
        float temp = (cam.transform.position.x * (1 - paralaxEffect));
        float dist = (cam.transform.position.x * paralaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        //cam.transform.Translate(Vector2.right * Time.deltaTime * speed);
        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
