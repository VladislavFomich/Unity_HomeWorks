using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public int positionWalk;
    public Transform startPoint;

    bool movingRight = true;

    Transform playerTransform;
    public float stopDistance;

    private SpriteRenderer sp;

    public GameObject player;

    bool walk = false;
    bool trigg = false;
    bool goBack = false;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, startPoint.position) < positionWalk && trigg == false)
        {
            walk = true;
        }
        if (Vector2.Distance(transform.position, playerTransform.position) < stopDistance)
        {
            trigg = true;
            walk = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, playerTransform.position) > stopDistance)
        {
            goBack = true;
            trigg = false;
        }
        if (walk == true)
        {
            Walk();
        }
       else if (trigg == true)
        {
            Trigg();
        }
       else if (goBack == true)
        {
            GoBack();
        }

    }

    void Walk()
    {
        if (transform.position.x > startPoint.position.x + positionWalk)
        {
            movingRight = false;
        }
        else if (transform.position.x < startPoint.position.x - positionWalk)
        {
            movingRight = true;
        }
        if (movingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
    }
    void Trigg()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
    }

    void GoBack()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.contacts[0].normal.y <= -0.7f)
            {
                Debug.Log("Смерть врага");
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Вы умерли");
                player.SetActive(false);
            }
        }
    }
}
