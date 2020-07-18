using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSC : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    public int maxJump;
    public float houseObject;
    bool isJumping = false;
    int jumpsLeft;
    int nowStage;

    //Mobile key set
    public bool LeftValue;
    public bool RightValue;
    public bool JumpValue;
    public bool EnterValue;
    bool left_Down;
    bool right_Down;
    bool left_Up;
    bool right_Up;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    private List<GameObject> collidingInteractables = new List<GameObject>();


    void Start()
    {
        //ButtonManager bm = GameObject.FindGameObjectWithTag("")
    }

    void Awake()
    {
        jumpsLeft = maxJump;
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    

    void Update()
    {
        //jump
        if (JumpValue == true||Input.GetButton("Jump"))
        {
            if (isJumping == false)
            {
                JumpValue = false;
                Debug.Log(isJumping);
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
                Debug.Log(isJumping);
            }
        }

        //move Flip
        if (Input.GetButton("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        if (Input.GetButtonUp("Horizontal"))

        
        rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        KeyCode interactKey = KeyCode.None;
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactKey = KeyCode.E;
        } else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            interactKey = KeyCode.UpArrow;
        }
        if (interactKey!=KeyCode.None) //interact
        {
            Debug.Log(collidingInteractables.Count);
            foreach (GameObject obj in collidingInteractables)
            {
                Interactable interactable = obj.GetComponent<Interactable>();
                if (interactable.interactKey == interactKey)
                    interactable.Interact();
            }
        }

            foreach (GameObject obj in collidingInteractables)
            {
                Interactable interactable = obj.GetComponent<Interactable>();
                if (EnterValue == true)
                    EnterValue = false;
                    interactable.Interact();
            }
        

    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h*5 , ForceMode2D.Impulse);
        

        if (rigid.velocity.x > maxSpeed)//Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))//Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));

            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

            if (rayHit.collider != null)
            {
                isJumping = false;
                Debug.Log(isJumping);
                Debug.Log(rayHit.collider.name);
            }
        }


        if(LeftValue == true){
            rigid.AddForce(Vector2.right *-1 , ForceMode2D.Impulse);
        }
        if(RightValue == true){
            rigid.AddForce(Vector2.right , ForceMode2D.Impulse);
        }
    }



    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "jumpTile"){
            rigid.AddForce(Vector2.up * 40, ForceMode2D.Impulse);
        }
        if(col.gameObject.tag == "jumpFake"){
            rigid.AddForce(Vector2.up * 80, ForceMode2D.Impulse);
        }

        if(col.gameObject.tag == "downTile"){
            Destroy(col.gameObject);
        }

        if(col.gameObject.tag == "Enemy"){
            OnDamaged(col.transform.position);
        }
    }

    void OnDamaged(Vector2 targetPos)
    {
        //Change Layer
        gameObject.layer = 13;
        //View Alpha
        spriteRenderer.color = new Color(1,1,1,0.4f);

        int dirc = transform.position.x-targetPos.x > 0 ? 1 : -1;
        rigid.AddForce(new Vector2(dirc,1)* 7, ForceMode2D.Impulse);

        //무적해제
        Invoke("OffDamaged", 1.5f);
    }

    void OffDamaged()
    {
        gameObject.layer = 12;
        spriteRenderer.color = new Color(1,1,1,1);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        

        Debug.Log(other.gameObject.name);
        if (other.gameObject.GetComponent<Interactable>()!=null)
        {
            if (!collidingInteractables.Contains(other.gameObject))
            {
                collidingInteractables.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Interactable>() != null)
        {
            collidingInteractables.Remove(other.gameObject);
        }
    }
    
    
/*
    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "L":
                leftValue = 1;
                break;
            case "R":
                rightValue = 1;
                break;

        }

    }
    
    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "L":
                leftValue = 0;
                break;
            case "R":
                rightValue = 0;
                break;

        }
    }
*/
}
