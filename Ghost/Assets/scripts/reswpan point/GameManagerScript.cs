using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManagerScript : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject gameOverUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        gameOverUI.SetActive(false);
        GameIsPaused = false;
    }

    void Pause()
    {
        gameOverUI.SetActive(true);
        GameIsPaused = true;
    }

    // Update is called once per frame
    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


     public void Exit()
    {
       Application.Quit();    
            
    }


     public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }




}
