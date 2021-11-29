using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    

    public Rigidbody2D rb;
    public SpriteRenderer sp;
    private BoxCollider2D BoxCollider2D;
    private CapsuleCollider2D CapCollider2D;
    private SpriteRenderer characterSprite;

    float rlMovement, udMovement;

    private float movementSpeed;
    private float jumpSpeed;
    private float timeSinceMovement = 0f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Sprite[] Idle;
    public Sprite[] Crouching;
    public Sprite[] Shooting;
    public Sprite[] ShootingUp;
    public Sprite[] RegularSprint;
    public Sprite[] ShootingSprint;

    bool isOnGround;
    bool isCrouching;
    bool ShootingStance;

    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        CapCollider2D = GetComponent<CapsuleCollider2D>();
        characterSprite = GetComponent<SpriteRenderer>();
        movementSpeed = 5;
        jumpSpeed = 5;
        isIdle(true);
    }

    void Update()
    {
        timeSinceMovement += Time.deltaTime;

        if(timeSinceMovement > 5f)
        {
            isIdle(true);
        }


        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                CrouchMovement(true);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Shot(true);
            }
        }


        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ShootUp(true);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Shot(true);
            }
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetButton("LightATK"))
            {
                Shot(true);
            }

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Shot(true);
            }


            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Shot(true);
            }
        }


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
        float rlMovement = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rlMovement = -1f;
            runMovement(true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rlMovement = 1f;
            runMovement(true);
        }

        Vector3 moveDir = new Vector3(rlMovement, 0);
        transform.position += moveDir * Time.deltaTime;

        transform.Translate(Time.fixedDeltaTime * (rlMovement * movementSpeed), Time.fixedDeltaTime * (udMovement * movementSpeed), 0);

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);

    }

    void JumpMovement()
    {
        rb.velocity = Vector2.up * jumpSpeed;
    }

    void isIdle(bool isIdle)
    {
        if (isIdle)
        {
            BoxCollider2D.offset = new Vector2(-0.01f, 0.03f);
            BoxCollider2D.size = new Vector2(0.21f, 0.27f);
            CapCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0f, -0.17f);
            CapCollider2D.size = new Vector2(0.16f, 0.16f);
            characterSprite.sprite = Idle[0];
        }
    }

    void CrouchMovement(bool isCrouching)
    {
        if (isCrouching)
        {
            timeSinceMovement = 0;
            BoxCollider2D.offset = new Vector2(0.05f, -0.12f);
            BoxCollider2D.size = new Vector2(0.25f, 0.25f);
            CapCollider2D.enabled = false;
            characterSprite.sprite = Crouching[0];
        }
    }

    void Shot(bool isShooting)
    {
        if (isShooting)
        {
            timeSinceMovement = 0;
            BoxCollider2D.offset = new Vector2(0.054f, 0.019f);
            BoxCollider2D.size = new Vector2(0.22f, 0.23f);
            CapCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0.03f, -0.167f);
            CapCollider2D.size = new Vector2(0.25f, 0.16f);
            characterSprite.sprite = Shooting[0];
        }
    }


    void ShootUp(bool isShootingUp)
    {
        if (isShootingUp)
        {
            timeSinceMovement = 0;
            Shot(false);
            characterSprite.sprite = ShootingUp[0];
        }
    }

    void runMovement(bool isRunning)
    {
        if (isRunning)
        {
            timeSinceMovement = 0;
            Shot(false);
            characterSprite.sprite = RegularSprint[0];
            characterSprite.sprite = ShootingSprint[0];
        }
    }
}
