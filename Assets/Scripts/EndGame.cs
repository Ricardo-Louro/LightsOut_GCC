using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject transition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponentInParent<PlayerMovement>() != null)
        {
            Destroy(collision.GetComponentInParent<PlayerMovement>());
            transition.SetActive(true);
            Invoke("ReturnToLevel0", 1.5f);
        }
    }

    private void ReturnToLevel0()
    {
        SceneManager.LoadScene(0);
    }
}