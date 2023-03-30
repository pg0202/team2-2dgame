using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false; //Set the cursor to not visible
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Check for "Esc" button press
        {
            if (!pauseMenu.activeSelf) //If pressed make the pause menu and cursor visable while pausing all other actions
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
                Cursor.visible = true;
            }
            else //If pressed again turn everyhting into false, disabling them and continuing the game
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
                Cursor.visible = false;
            }
        }
    }

    public void quit()
    {
        SceneManager.LoadScene(0); //Quits to the Main Menu.
    }

    public void resume() //If pressed turn everyhting into false, disabling them and continuing the game
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        Cursor.visible = false;
    }
}
