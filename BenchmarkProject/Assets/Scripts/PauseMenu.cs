using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool paused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pauseMenu.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            pauseMenu.SetActive(false);
            paused = false;
            Time.timeScale = 1;
        }
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}
