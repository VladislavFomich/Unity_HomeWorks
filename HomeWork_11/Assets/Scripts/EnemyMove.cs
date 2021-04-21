using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent agent;
    public Vector3 pointMove;
    public bool inPosition = false;
    Vector3 startPos;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        agent.SetDestination(pointMove);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, pointMove) < 0.5f)
            agent.SetDestination(startPos);

        else if (Vector3.Distance(transform.position, startPos) < 0.5f)
            agent.SetDestination(pointMove);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("You die");
        }
    }
}
