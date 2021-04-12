using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public GameObject coin;
    
    public PlayerMove scoreView;

    Collider2D col;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Открываем!");
            scoreView.score++;
            anim.SetBool("isOpened", true);
            coin.SetActive(true);
            Destroy(coin, 1f);
            Destroy(col);

        }
    }

}
