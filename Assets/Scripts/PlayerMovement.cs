using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private bool grounded;
    private bool jump = false;

    [Header("Values")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float moveDirection;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        ReceiveInput();
        CheckForJump();
        UpdateSprite();
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
    }

    private void ReceiveInput()
    {
        moveDirection = Input.GetAxis("Horizontal");
    }

    private void CheckForJump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump = true;
        }
    }

    private void UpdateSprite()
    {
        animator.SetFloat("moveDirection", moveDirection);
        animator.SetBool("jump", jump);

        if (moveDirection > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveDirection < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void UpdateSpeed()
    {
        Vector3 speed = transform.right * moveDirection * moveSpeed;

        if (jump)
        {
            jump = false;
            speed.y = Mathf.Max(jumpSpeed, rb.linearVelocity.y);
        }
        else
        {
            speed.y = rb.linearVelocity.y;
        }

        rb.linearVelocity = speed;
    }

    public void SetGrounded(bool status)
    {
        grounded = status;
    }

    public void SetVerticalSpeed(float value)
    {
        Vector3 speed = rb.linearVelocity;
        speed.y = value;
        rb.linearVelocity = speed;
    }
}