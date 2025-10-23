using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    private PauseGame pauseGame;

    private void Start()
    {
        pauseGame = FindFirstObjectByType<PauseGame>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && !pauseGame.paused)
        {
            RestartLevel();
        }
    }

    public void RestartLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DelayRestart(float delay)
    {
        Invoke("RestartLevel", delay);
    }

    public void NextLevel()
    {
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch (Exception e)
        {
            SceneManager.LoadScene(0);
        }
    }
}