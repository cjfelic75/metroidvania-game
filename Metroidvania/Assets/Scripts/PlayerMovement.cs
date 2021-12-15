using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    

    public Rigidbody2D rb;
    public SpriteRenderer sp;
    private BoxCollider2D BoxCollider2D;
    private CapsuleCollider2D CapCollider2D;
    private objectOffset bulletOffset;
    private SpriteRenderer characterSprite;
    public Transform FirePoint;
    public Animator animatonToggle;

    float rlMovement, udMovement;

    private float movementSpeed;
    private float jumpSpeed;
    private float timeSinceMovement = 0f;
    private bool isLookingRight;
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
        movementSpeed = 3;
        jumpSpeed = 7;
        isLookingRight = true;
        isIdle(true);

        GameObject bullet = GameObject.FindWithTag("BulletSpawn");
        if (bullet != null)
        {
            bulletOffset = bullet.GetComponent<objectOffset>();
        }
    }

    void Update()
    {
        timeSinceMovement += Time.deltaTime;

        if (timeSinceMovement <= 5f)
        {
            isIdle(false);
        }

        if (timeSinceMovement > 5f)
        {
            Shot(false);
            isIdle(true);
        }


        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            animatonToggle.SetBool("isRunning", false);
            if (Input.GetKey(KeyCode.DownArrow))
            {
                CrouchMovement(true);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                CrouchMovement(false);
                Shot(true);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                ShootUp(true);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                ShootUp(false);
                Shot(true);
            }
        }

        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            animatonToggle.SetBool("isRunning", false);

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


        if (Input.GetKey(KeyCode.Space))
        {
            if (isOnGround)
            {
                JumpMovement(true);
            }
        }
        if (!Input.GetKey(KeyCode.Space))
        {
            if (isOnGround)
            {
                JumpMovement(false);
            }
        }
    }

    void FixedUpdate()
    {
        float rlMovement = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rlMovement = -1f;
            runMovement(true, -1f);
            flip(-1f);
            animatonToggle.SetBool("isRunning", true);
            ShootUp(false);
            CrouchMovement(false);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rlMovement = 1f;
            runMovement(true, 1f);
            flip(1f);
            animatonToggle.SetBool("isRunning", true);
            ShootUp(false);
            CrouchMovement(false);
        }

        Vector3 moveDir = new Vector3(rlMovement, 0);
        transform.position += moveDir * Time.deltaTime;

        transform.Translate(Time.fixedDeltaTime * (rlMovement * movementSpeed), Time.fixedDeltaTime * (udMovement * movementSpeed), 0);

        isOnGround = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);

    }

    void JumpMovement(bool isJumping)
    {
        if (isJumping)
        {
            rb.velocity = Vector2.up * jumpSpeed;
            animatonToggle.SetBool("isJumping", true);
        }
        if (!isJumping)
        {
            animatonToggle.SetBool("isJumping", false);
        }
    }
    void isIdle(bool isIdle)
    {
        if (isIdle)
        {
            BoxCollider2D.offset = new Vector2(-0.01f, 0.03f);
            BoxCollider2D.size = new Vector2(0.21f, 0.27f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0f, -0.17f);
            CapCollider2D.size = new Vector2(0.16f, 0.16f);
            animatonToggle.SetBool("isIdle", true);
        }
        if (!isIdle)
        {
            animatonToggle.SetBool("isIdle", false);
        }
    }

    void CrouchMovement(bool isCrouching)
    {
        if (isCrouching)
        {
            timeSinceMovement = 0;
            CapCollider2D.offset = new Vector2(0.02f, -0.125f);
            CapCollider2D.size = new Vector2(0.3f, 0.256f);
            BoxCollider2D.enabled = false;
            animatonToggle.SetBool("isCrouching", true);
            bulletOffset.offset = new Vector3(0.53f, -0.27f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!isLookingRight)
            {
                bulletOffset.offset = new Vector3(-0.53f, -0.27f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        if (!isCrouching)
        {
            animatonToggle.SetBool("isCrouching", false);
        }
    }

    void Shot(bool isShooting)
    {
        if (isShooting)
        {
            timeSinceMovement = 0;
            BoxCollider2D.offset = new Vector2(0.054f, 0.019f);
            BoxCollider2D.size = new Vector2(0.22f, 0.23f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0.03f, -0.167f);
            CapCollider2D.size = new Vector2(0.25f, 0.16f);
            animatonToggle.SetBool("isShooting", true);
            bulletOffset.offset = new Vector3(0.53f, 0.08f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (!isLookingRight)
            {
                bulletOffset.offset = new Vector3(-0.53f, 0.08f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
        if (!isShooting)
        {
            animatonToggle.SetBool("isShooting", false);
        }
    }


    void ShootUp(bool isShootingUp)
    {
        if (isShootingUp)
        {
            timeSinceMovement = 0;
            Shot(false);
            BoxCollider2D.offset = new Vector2(0.02f, 0.04f);
            BoxCollider2D.size = new Vector2(0.15f, 0.25f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0.03f, -0.155f);
            CapCollider2D.size = new Vector2(0.25f, 0.19f);
            animatonToggle.SetBool("isLookingUp", true);


            bulletOffset.offset = new Vector3(0.11f, 0.51f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 90f);

            if (!isLookingRight)
            {
                bulletOffset.offset = new Vector3(-0.11f, 0.51f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
        if (!isShootingUp)
        {
            animatonToggle.SetBool("isLookingUp", false);
        }
    }

    void runMovement(bool isRunning, float rlMovement)
    {
        if (isRunning)
        {
            timeSinceMovement = 0;
            Shot(false);
            BoxCollider2D.offset = new Vector2(0.04f,-0.003f);
            BoxCollider2D.size = new Vector2(0.24f, 0.22f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(-0.04f, -0.17f);
            CapCollider2D.size = new Vector2(0.2f, 0.15f);

            bulletOffset.offset = new Vector3(0.53f, 0f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (!isLookingRight && rlMovement < 0)
            {
                bulletOffset.offset = new Vector3(-0.53f, 0f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }

    void flip(float rlMovement)
    {
        if(rlMovement > 0 && !isLookingRight || rlMovement < 0 && isLookingRight)
        {
            isLookingRight = !isLookingRight;

            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}


/*
 * using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    

    public Rigidbody2D rb;
    public SpriteRenderer sp;
    private BoxCollider2D BoxCollider2D;
    private CapsuleCollider2D CapCollider2D;
    private objectOffset bulletOffset;
    private SpriteRenderer characterSprite;
    public Transform FirePoint;
    public Animator animatonToggle;

    float rlMovement, udMovement;

    private float movementSpeed;
    private float jumpSpeed;
    private float timeSinceMovement = 0f;
    private bool isLookingRight;
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
        isLookingRight = true;
        isIdle(true);

        GameObject bullet = GameObject.FindWithTag("BulletSpawn");
        if (bullet != null)
        {
            bulletOffset = bullet.GetComponent<objectOffset>();
        }
    }

    void Update()
    {
        timeSinceMovement += Time.deltaTime;

        if(timeSinceMovement <= 5f)
        {
            animatonToggle.SetBool("isIdle", false);
        }
        if(timeSinceMovement > 5f)
        {
            isIdle(true);
            animatonToggle.SetBool("isShooting", false);
            animatonToggle.SetBool("isIdle", true);
        }


        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {

            animatonToggle.SetBool("isRunning", false);
            if (Input.GetKey(KeyCode.DownArrow))
            {
                CrouchMovement(true);
                animatonToggle.SetBool("isCrouching", true);
            }

            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Shot(true);
                animatonToggle.SetBool("isCrouching", false);
            }
        }


        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            animatonToggle.SetBool("isRunning", false);

            if (Input.GetKey(KeyCode.UpArrow))
            {
                ShootUp(true);
                animatonToggle.SetBool("isShootingUp", true);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Shot(true);
                animatonToggle.SetBool("isShootingUp", false);
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
                animatonToggle.SetBool("isRunning", false);
            }


            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Shot(true);
                animatonToggle.SetBool("isRunning", false);
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
            animatonToggle.SetBool("isRunning", true);
            runMovement(true, -1f);
            flip(-1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rlMovement = 1f;
            animatonToggle.SetBool("isRunning", true);
            runMovement(true, 1f);
            flip(1f);
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
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0f, -0.17f);
            CapCollider2D.size = new Vector2(0.16f, 0.16f);
        }
    }

    void CrouchMovement(bool isCrouching)
    {
        if (isCrouching)
        {
            timeSinceMovement = 0;
            CapCollider2D.offset = new Vector2(0.02f, -0.125f);
            CapCollider2D.size = new Vector2(0.3f, 0.256f);
            BoxCollider2D.enabled = false;
            bulletOffset.offset = new Vector3(0.53f, -0.27f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 0f);
            if (!isLookingRight)
            {
                bulletOffset.offset = new Vector3(-0.53f, -0.27f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }

    void Shot(bool isShooting)
    {
        if (isShooting)
        {
            timeSinceMovement = 0;
            BoxCollider2D.offset = new Vector2(0.054f, 0.019f);
            BoxCollider2D.size = new Vector2(0.22f, 0.23f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0.03f, -0.167f);
            CapCollider2D.size = new Vector2(0.25f, 0.16f);
            bulletOffset.offset = new Vector3(0.53f, 0.08f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (!isLookingRight)
            {
                bulletOffset.offset = new Vector3(-0.53f, 0.08f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }


    void ShootUp(bool isShootingUp)
    {
        if (isShootingUp)
        {
            timeSinceMovement = 0;
            Shot(false);
            BoxCollider2D.offset = new Vector2(0.02f, 0.04f);
            BoxCollider2D.size = new Vector2(0.15f, 0.25f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(0.03f, -0.155f);
            CapCollider2D.size = new Vector2(0.25f, 0.19f);
            bulletOffset.offset = new Vector3(0.11f, 0.51f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 90f);

            if (!isLookingRight)
            {
                bulletOffset.offset = new Vector3(-0.11f, 0.51f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 0f, 90f);
            }
        }
    }

    void runMovement(bool isRunning, float rlMovement)
    {
        if (isRunning)
        {
            timeSinceMovement = 0;
            Shot(false);
            BoxCollider2D.offset = new Vector2(0.04f,-0.003f);
            BoxCollider2D.size = new Vector2(0.24f, 0.22f);
            BoxCollider2D.enabled = true;
            CapCollider2D.offset = new Vector2(-0.04f, -0.17f);
            CapCollider2D.size = new Vector2(0.2f, 0.15f);

            bulletOffset.offset = new Vector3(0.53f, 0f, 0f);
            FirePoint.rotation = Quaternion.Euler(0f, 0f, 0f);

            if (!isLookingRight && rlMovement < 0)
            {
                bulletOffset.offset = new Vector3(-0.53f, 0f, 0f);
                FirePoint.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
        }
    }

    void flip(float rlMovement)
    {
        if(rlMovement > 0 && !isLookingRight || rlMovement < 0 && isLookingRight)
        {
            isLookingRight = !isLookingRight;

            Vector3 Scale = transform.localScale;
            Scale.x *= -1;
            transform.localScale = Scale;
        }
    }
}
*/