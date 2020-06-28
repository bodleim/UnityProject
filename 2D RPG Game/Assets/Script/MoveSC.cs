using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSC : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public int maxJump;
    int jumpsLeft;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    
    void Awake()
    {
        jumpsLeft = maxJump;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //jump
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            jumpsLeft--;
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }

        //move Flip
        if(Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        if(Input.GetButtonUp("Horizontal")) 
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right *h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed)//Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1))//Left Max Speed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            float colHalfWidth = col.gameObject.transform.lossyScale.x / 2;
            float colLeftX = col.gameObject.transform.position.x - colHalfWidth;
            float colRightX = col.gameObject.transform.position.x + colHalfWidth;
            float playerHalfWidth = transform.lossyScale.x / 2;
            float playerLeftX = transform.position.x - playerHalfWidth;
            float playerRightX = transform.position.x + playerHalfWidth;
            if(playerLeftX<=colRightX-0.1f && playerRightX >= colLeftX+0.1f)
            {
                if (transform.position.y > col.gameObject.transform.position.y)
                {
                    jumpsLeft = maxJump;
                    transform.position = new Vector2(transform.position.x, col.gameObject.transform.position.y + col.gameObject.transform.lossyScale.y / 2 + transform.lossyScale.y / 2);
                }
            }
        }
    }
    

}
