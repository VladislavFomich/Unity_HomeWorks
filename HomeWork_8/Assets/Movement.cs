
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 300;
    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;

    bool isRight = true;

    void Start()
    {

        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > ScreenWidth / 2)
            {

                if (isRight == false)
                {
                    Flip();
                }
              
                RunCharacter(1.0f);
            }
            if (Input.GetTouch(i).position.x < ScreenWidth / 2)
            {
                if (isRight == true)
                {
                    Flip();
                }
                RunCharacter(-1.0f);
            }
            ++i;
        }
    }

    private void RunCharacter(float horizontalInput)
    {
       // characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
        characterBody.velocity = new Vector2(horizontalInput * moveSpeed, 0);
    }
    void Flip()
    {
        isRight = !isRight;
        Vector2 scaler = character.transform.localScale;
        scaler.x *= -1;
        character.transform.localScale = scaler;
    }
}