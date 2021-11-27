using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    

    public Rigidbody2D rb;
    public SpriteRenderer sp;

    float xAxis, yAxis;

    public float movementSpeed;
    public float jumpSpeed;
    public Transform groundCheck;
    public LayerMask groundLayer;

    bool isOnGround;
    
    
   
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isOnGround)
            {
                JumpMovement();
            }      
        }

    }

    void FixedUpdate()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        yAxis = Input.GetAxisRaw("Vertical");

        transform.Translate(Time.fixedDeltaTime * (xAxis * movementSpeed), Time.fixedDeltaTime * (yAxis * movementSpeed), 0);

        playerMove(); 
        flipSprite();

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);
    }

    void JumpMovement()
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }

    void playerMove()
    {
        rb.velocity = new Vector2(movementSpeed * xAxis, rb.velocity.y);
    }

    void flipSprite()
    {
        if (rb.velocity.x < -0.1f)
        {
            sp.flipX = true;
        }

        if (rb.velocity.x > 0.1f)
        {
            sp.flipX = false;
        }
    }
}
