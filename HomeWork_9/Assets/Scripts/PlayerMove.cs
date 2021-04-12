using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    public bool onGround;
    public float checkRadius = 0.5f;

    public LayerMask Ground;
    public float speed = 2f;
    public float jumpForce;
    public Transform groundCheck;
    public int score = 0;
    public GameObject textScore;

    Vector2 moveVector;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Walk();
        Flip();
        Jump();
        CheckingGround();
        TextScore();
    }

    void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    void Flip()
    {
        if (moveVector.x > 0)
        {
            sr.flipX = false;
        }
        else if (moveVector.x < 0)
        {
            sr.flipX = true;
        }
    }
   
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
    void CheckingGround ()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }         

    void TextScore()
    {
        textScore.GetComponent<Text>().text = "= " + score.ToString();
    }
}
