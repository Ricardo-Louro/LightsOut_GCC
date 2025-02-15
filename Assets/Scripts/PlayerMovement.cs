using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private bool jump = false;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 speed = transform.right * Input.GetAxis("Horizontal") * moveSpeed;
        
        if(jump)
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
}