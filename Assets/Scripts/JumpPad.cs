using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement playerMovement = other.GetComponentInParent<PlayerMovement>();
        if(playerMovement != null)
        {
            playerMovement.SetVerticalSpeed(speed);
            animator.SetTrigger("Activate");
        }
    }
}