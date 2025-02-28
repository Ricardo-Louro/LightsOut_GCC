using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoor : MonoBehaviour
{
    private bool open = false;
    [SerializeField] private GameObject closedDoorSprite;
    [SerializeField] private GameObject openDoorSprite;

    [SerializeField] private GameObject transition;

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
            Destroy(collision.GetComponentInParent<PlayerMovement>());
            transition.SetActive(true);
            Invoke("NextLevel", 1.5f);
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}