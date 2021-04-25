using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryFrameParticle : MonoBehaviour
{
    public GameObject particleEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(particleEffect, transform.position, transform.rotation);
    }
}
