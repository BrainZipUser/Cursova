using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    public static bool isPause = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && FP_Character.isPlay)
        {
            if (isPause)
                Resume();
            else
                Pause();
        }   
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        isPause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        isPause = true;
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0f;
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
