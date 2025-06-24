using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping"))
        {
            animator.SetTrigger("land");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovement.SetGrounded(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(SetGroundedOff(.1f));
    }

    private IEnumerator SetGroundedOff(float coyoteTime)
    {
        yield return new WaitForSeconds(coyoteTime);
        playerMovement.SetGrounded(false);
    }
}