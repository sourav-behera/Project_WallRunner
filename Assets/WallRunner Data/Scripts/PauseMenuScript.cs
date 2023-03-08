using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuScript : MonoBehaviour
{
    public bool isPaused = false;
    public GameObject pauseMenuUI;
    public static PauseMenuScript pauseMenuScript;

 
    private void Start()
    {   
        if (pauseMenuScript == null) pauseMenuScript = this;
        pauseMenuUI.SetActive(false);
        Cursor.visible = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    void Pause()
    {
        isPaused = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void _Resume()
    {
        Resume();
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
