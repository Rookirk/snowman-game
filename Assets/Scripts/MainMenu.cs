using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // The Scene Manager is referenced & loads Snow Scene by string/name
    public void PlayGame()
    {
        SceneManager.LoadScene("SnowScene"); 
    }

    // The Scene Manager is referenced & loads Credits Menu by string/name
    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu"); 
    }

    // The Scene Manager is referenced & loads Main Menu by string/name
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }

    // This function quits the game & application
    public void QuitGame()
    {
        Application.Quit();
    }

}
