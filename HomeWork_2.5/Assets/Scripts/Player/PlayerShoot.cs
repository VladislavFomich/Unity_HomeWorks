using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour    
{
   private int ammoNum;
    public Transform spawnPoint;
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            BulletManager.Instance.BulletAwake(spawnPoint.position, spawnPoint.gameObject.transform.rotation, ammoNum);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ammoNum = other.GetComponent<Ammo>().bulletID;
        Debug.Log(ammoNum);
    }
}
