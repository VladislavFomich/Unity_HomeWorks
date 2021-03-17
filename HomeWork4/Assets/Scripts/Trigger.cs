using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject shellsSpawnPoint;
    public GameObject grenadesSpawnPoint;
    public GameObject tennisSpawnPoint;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Shells")
        {
            shellsSpawnPoint.SetActive(true);
            grenadesSpawnPoint.SetActive(false);
            tennisSpawnPoint.SetActive(false);
            Debug.Log("Shells");
        }
        if (other.gameObject.tag == "Tennis")
        {
            shellsSpawnPoint.SetActive(false);
            grenadesSpawnPoint.SetActive(false);
            tennisSpawnPoint.SetActive(true);
            Debug.Log("Tennis");
        }
        if (other.gameObject.tag == "Grenades")
        {
            shellsSpawnPoint.SetActive(false);
            grenadesSpawnPoint.SetActive(true);
            tennisSpawnPoint.SetActive(false);
            Debug.Log("Grenades");
        }
    }
}
