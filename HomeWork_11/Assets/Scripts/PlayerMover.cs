using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    private Camera cam;
    private NavMeshAgent agent;
    float defaultSpeed;
    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    agent.SetDestination(hit.point);
                }
            }
        }
        NavMeshHit hitt;
        NavMesh.SamplePosition(agent.transform.position, out hitt, 1.1f, NavMesh.AllAreas);
        int index = IndexFromMask(hitt.mask);
        if (index >= 0)
        {
            Debug.Log(index + " " + agent.GetAreaCost(index));
            agent.speed = defaultSpeed / agent.GetAreaCost(index);
        }
        else 
        {
            Debug.LogWarning(index);
        }
     
    }
    private int IndexFromMask(int mask)
    {
        for (int i = 0; i < 32; ++i)
        {
            if ((1 << i) == mask)
                return i;
        }
        return -1;
    }
}
