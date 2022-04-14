using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Admin : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool paused = false;
    void Update()
    {

        if(Input.GetKeyDown("escape") && paused == false)
        {
            
            pauseGame();
        }
        if (Input.GetKeyDown("escape") && paused == true)
        {

            resumeGame();
        }
    }

    public void pauseGame()
    {
        Debug.Log("pause");
        pauseMenu.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }
    public void resumeGame()
    {
        
        pauseMenu.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
