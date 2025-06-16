using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private bool startOption = true;

    [SerializeField] private TextMeshProUGUI start;
    [SerializeField] private TextMeshProUGUI quit;

    private float timeStarted;

    private void Start()
    {
        timeStarted = Time.time;
    }

    private void Update()
    {
        if(Time.time - timeStarted >= 3)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow) ||
               Input.GetKeyDown(KeyCode.DownArrow) ||
               Input.GetKeyDown(KeyCode.W) ||
               Input.GetKeyDown(KeyCode.S))
            {
                startOption = !startOption;
            }

            if(startOption)
            {
                start.color = new Color(1, 1, 1, 1);
                quit.color = new Color(1, 1, 1, .15f);
            }
            else
            {
                start.color = new Color(1, 1, 1, .15f);
                quit.color = new Color(1, 1, 1, 1);
            }

            if(Input.GetKeyDown(KeyCode.Return))
            {
                if(startOption)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }
}