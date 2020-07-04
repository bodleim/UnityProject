using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoMon : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Think();
    }


    void FixedUpdate()
    {
        //Move
        rigid.velocity = new Vector2(nextMove, rigid.velocity.y);

        //Platform Check
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.5f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if(rayHit.collider == null){
           // Debug.Log("땅 없음 인식.");
            nextMove *= -1;
            //reverse
            CancelInvoke();
            Invoke("Think", 3);
        }

    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        float nextThinkTime = Random.Range(1f,5f);
        if(nextMove == 0){
            anim.SetBool("isWalking", false);
        }
        else if(nextMove != 0){
            anim.SetBool("isWalking", true);
        }
        Invoke("Think", nextThinkTime);
        if(nextMove != 0)
            spriteRenderer.flipX = nextMove == 1;
    }

}
