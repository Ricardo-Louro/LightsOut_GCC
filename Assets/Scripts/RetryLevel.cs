using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryLevel : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F1))
        {
            NextLevel();
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