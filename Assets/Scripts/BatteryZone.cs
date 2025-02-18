using UnityEngine;

public class BatteryZone : MonoBehaviour
{
    [SerializeField] private GameObject darkness;
    private ExitDoor exitDoor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        exitDoor = FindFirstObjectByType<ExitDoor>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null)
        {
            spriteRenderer.enabled = false;
            darkness.SetActive(true);
            exitDoor.Open();
            Destroy(this);
        }
    }
}