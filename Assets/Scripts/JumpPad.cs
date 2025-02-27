using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float speed;
    private Animator animator;
    private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement playerMovement = other.GetComponentInParent<PlayerMovement>();
        if(playerMovement != null)
        {
            audioSource.pitch = Random.Range(.8f, 1f);
            audioSource.PlayOneShot(audioClip);

            playerMovement.SetVerticalSpeed(speed);
            animator.SetTrigger("Activate");
        }
    }
}