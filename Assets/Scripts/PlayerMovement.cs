using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private PauseGame pauseGame;

    private Rigidbody2D rb;

    private bool grounded;
    private bool jump = false;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip deathClip;

    [Header("Values")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private RetryLevel retryLevel;

    private float moveDirection;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Start()
    {
        pauseGame = FindAnyObjectByType<PauseGame>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        retryLevel = GetComponent<RetryLevel>();
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

        if(jump)
        {
            audioSource.pitch = Random.Range(0.7f, 1f);
            audioSource.PlayOneShot(jumpClip);

            jump = false;
            speed.y = Mathf.Max(jumpSpeed, rb.linearVelocity.y);
            SetGrounded(false);
        }
        else
        {
            speed.y = rb.linearVelocity.y;
        }

        rb.linearVelocity = speed;

        if(pauseGame.paused)
        {
            rb.linearVelocity = Vector3.zero;
        }
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

    public void Die()
    {
        animator.SetTrigger("die");
        audioSource.PlayOneShot(deathClip);
        retryLevel.DelayRestart(2.5f);
        Destroy(rb);
        Destroy(this);
    }

    public Vector3 StoreVelocity()
    {
        return rb.linearVelocity;
    }

    public void SetVelocity(Vector3 playerVelocity)
    {
        rb.linearVelocity = playerVelocity;
    }
}