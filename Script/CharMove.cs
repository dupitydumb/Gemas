using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMove : MonoBehaviour
{
    public float speed ;
    public int HP = 50;
    public int damage = 10;


    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer Sr;

    public SavePos savePos;
    public QuestManager questManager;

    enum CharMoveState
    {
        idle,
        walk,
        attack,
        interact,
        Left,
        Right
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
        transform.position = savePos.startpoint;
    }

    

    /*private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }*/

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
        //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //anim.SetBool("Walk", true);

        if (movement > 0 || movement < 0)
        {
            transform.localScale = new Vector2(0.8f * movement, 0.8f);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-speed , rb.velocity.y);
            anim.SetBool("Walk", true);
            anim.SetBool("idle", false);
            //Sr.flipX = true;
            
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("Walk", true);
            anim.SetBool("idle", false);
            //Sr.flipX = false;

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("Walk", false);
            
            anim.SetBool("idle", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
   
            anim.SetBool("Attack", true);
   
        }
        else
        {
            anim.SetBool("Attack", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            speed = 0.0f;
        }
        else
        {
            speed = 5f;
        }

    }

    public void TakeDamage(int damage){
        HP -= damage;
        if(HP <= 0){
            Destroy(gameObject);
        }
    }

    void Attack()
    {
        anim.SetBool("Attack", true);
    }

    public void FreezeMovement()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
