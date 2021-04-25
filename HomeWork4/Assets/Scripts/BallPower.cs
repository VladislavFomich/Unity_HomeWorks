using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPower : MonoBehaviour
{
    Rigidbody body;
    public float force = 300.0f;
    public float timeDestroy;

    void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward * force);
        Destroy(gameObject, timeDestroy);

    }
}
