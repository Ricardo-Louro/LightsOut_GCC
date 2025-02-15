using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private bool grounded;
    private bool jump = false;

    [Header("Values")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        UpdateSpeed();
    }

    private void UpdateSpeed()
    {
        Vector3 speed = transform.right * Input.GetAxis("Horizontal") * moveSpeed;

        if (jump)
        {
            jump = false;
            speed.y = jumpSpeed;
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
}