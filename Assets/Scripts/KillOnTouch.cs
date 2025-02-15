using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}