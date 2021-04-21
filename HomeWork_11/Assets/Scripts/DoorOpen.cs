using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorOpen : MonoBehaviour
{
    public GameObject door;
    public NavMeshSurface navMeshSurface;



    bool isTrigg = false;
    bool isGenerate = false;

    private void Update()
    {
        if (isGenerate == true)
        {
            isGenerate = false;
            navMeshSurface.BuildNavMesh();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (isTrigg == false)
            {
                isTrigg = true;
                isGenerate = true;
                Debug.Log("Trigger");
                Destroy(door);
               
            }
        }
    }
}
