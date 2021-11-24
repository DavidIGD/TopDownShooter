using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScreen : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//loads the next scene
    }

    public void QuitGame()
    {
        Application.Quit();//quits the application
    }

    public void Return()
    {
        SceneManager.LoadScene("Start Menu");//returns to the start menu
    }
}