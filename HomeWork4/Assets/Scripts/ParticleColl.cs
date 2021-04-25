using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleColl : MonoBehaviour
{
    public GameObject particleEffect;

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(particleEffect, transform.position, transform.rotation);
    }
}
