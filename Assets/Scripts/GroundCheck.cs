using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
      playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerMovement.SetGrounded(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerMovement.SetGrounded(false);
    }
}
