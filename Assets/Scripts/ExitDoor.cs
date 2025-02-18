using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private bool open = false;
    [SerializeField] private GameObject closedDoorSprite;
    [SerializeField] private GameObject openDoorSprite;

    public void Open()
    {
        closedDoorSprite.SetActive(false);
        openDoorSprite.SetActive(true);
        open = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null && open)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}