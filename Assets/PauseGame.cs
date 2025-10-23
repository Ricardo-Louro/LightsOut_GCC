using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool paused = false;
    private PlayerMovement playerMovement;
    [SerializeField] private GameObject pauseVisualComponents;

    private Vector3 playerVelocity;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused = !paused;
            ToggledPause();
        }

        if(Input.GetKeyDown(KeyCode.Return) && paused)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void ToggledPause()
    {
        pauseVisualComponents.SetActive(paused);

        if(paused)
        {
            playerMovement.GetComponent<Rigidbody2D>().gravityScale = 0;
            playerVelocity = playerMovement.StoreVelocity();
        }
        else
        {
            playerMovement.GetComponent<Rigidbody2D>().gravityScale = 1;
            playerMovement.SetVelocity(playerVelocity);

        }
    }
}
