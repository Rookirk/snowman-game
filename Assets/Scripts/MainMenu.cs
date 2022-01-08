using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // This function references the Scene Manager & loads Snow Scene by string/name
    public void PlayGame()
    {
        SceneManager.LoadScene("SnowScene"); 
    }

    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu"); 
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    // This function quits the game & application. 
    public void QuitGame()
    {
        Application.Quit();
    }

}
