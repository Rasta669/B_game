using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    bool isGrounded = false;
    float jumpForce = 10.0f;
    float Xmovement;
    float Ymovement;
    private Rigidbody2D rb;
    [SerializeField] float Xspeed = 2.0f;
    [SerializeField] Spawn spawn;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("spawn1").GetComponent<Spawn>();
        animator = GameObject.Find("PLAYER").GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.isGameActive)
        {
            Ymovement = Input.GetAxis("Vertical");
            Xmovement = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(0, Ymovement);
            //Vector2 movement = new Vector2(Xmovement, 0);
            //transform.Translate(movement * Time.deltaTime);
            MoveX();


            if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Jump(movement);
                rb.AddForce(movement * jumpForce, ForceMode2D.Impulse);
            }

            //if (Input.GetKeyDown(KeyCode.RightArrow)) {
                
            //}

        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contactPoint = collision.GetContact(0);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void Jump(Vector2 movement)
    {
        
        rb.AddForce(movement * jumpForce, ForceMode2D.Impulse);

    }

    void MoveX()
    {
        
        Vector2 movement = new Vector2(Xmovement, 0);
        transform.Translate(movement * Time.deltaTime* Xspeed);
        animator.SetTrigger("idleToWalk");


    }
}

