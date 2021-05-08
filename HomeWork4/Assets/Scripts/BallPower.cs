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
        StartCoroutine(ballOff());

    }

    IEnumerator ballOff()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
