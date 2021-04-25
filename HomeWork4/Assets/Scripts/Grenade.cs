using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    public float explosionForce = 10f;
    public float radius = 20f;
    public GameObject particleEffect;
    void Start()
    {
        Invoke("Explode", delay);
    }

   private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider near in colliders)
        {
            Rigidbody rig = near.GetComponent<Rigidbody>();
            if (rig !=null)
            {
                rig.AddExplosionForce(explosionForce, transform.position, radius, 1f, ForceMode.Impulse);
            }
        }
        Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
