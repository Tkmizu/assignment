using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float driX;
    private BoxCollider2D coll;
    private Animator anim;
    [SerializeField] private float jump = 14f;
    [SerializeField] private float move = 10f;
    private bool isdisabled = false;
    private bool isJumping = false;

    public bool isFacingRight = true;
    public LayerMask jumpableground;

    private bool ground;

    public LevelLoader levelLoader;

    public Winning winning;



    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        driX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(driX * move, rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow) && IsGrounded())
        {
                   Jump();
            
        }

        anim.SetBool("running", driX != 0);
        anim.SetBool("grounded", ground);
   


        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (driX > 0f && !isFacingRight)
        {
            Flip();

        }
        else if (driX < 0f && isFacingRight) 
        {
            Flip();
        }
      
       
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump);
        anim.SetTrigger("jump");
        ground = false;
        isJumping = true;
        Invoke("StopJump", 3f); // Gọi hàm StopJump() sau 3s
    }
 void StopJump()
    {
        isJumping = false;
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            ground = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NextStage")
        {
            levelLoader.LoadNextLevel();
            rb.bodyType = RigidbodyType2D.Static;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
        }

        if(collision.gameObject.tag == "EndStage")
        {
            winning.winningScence();
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private bool IsGrounded()
    {
        ground = false;
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableground);
    }


}
