using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoChoice : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        int ammoNum = other.GetComponent<Ammo>().bulletID;
        Debug.Log(ammoNum);
    }
}
