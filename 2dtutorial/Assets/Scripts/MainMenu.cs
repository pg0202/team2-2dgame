using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Joshua Longthorpe

public class MainMenu : MonoBehaviour
{
    public void PlayGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Loads the next scene.
    }

    public void QuitGame()
    {
        Application.Quit(); //closes the application/game fully.
    }
}