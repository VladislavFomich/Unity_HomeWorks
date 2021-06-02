using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public delegate void HitTheTargetDelegate(BulletForce bullet);
    public event HitTheTargetDelegate OnBulletHit;

    public float force = 300.0f;
    public void CustomStart()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnBulletHit?.Invoke(this);
    }

}
