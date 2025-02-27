using UnityEngine;

public class BatteryZone : MonoBehaviour
{
    [SerializeField] private GameObject darkness;
    private ExitDoor exitDoor;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private void Start()
    {
        exitDoor = FindFirstObjectByType<ExitDoor>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null)
        {
            audioSource.pitch = .7f;
            audioSource.Play();
            spriteRenderer.enabled = false;
            darkness.SetActive(true);
            exitDoor.Open();
            Destroy(this);
        }
    }
}