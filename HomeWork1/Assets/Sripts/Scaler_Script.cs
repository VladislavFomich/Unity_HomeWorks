using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler_Script : MonoBehaviour
{
    public float speed = 1.0f;
    private float min = 0.5f;
    private float max = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            transform.localScale = new Vector3(Mathf.PingPong(Time.time * speed, (max - min)) + max, Mathf.PingPong(Time.time * speed, max - min) + max, Mathf.PingPong(Time.time * speed, max - min) + max);
    }
}
