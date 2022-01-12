using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // The Scene Manager is referenced & loads Snow Scene by string/name
    public void PlayGame()
    {
        AudioManager.Instance?.PlayMenuClick();
        SceneManager.LoadScene("SnowScene"); 
    }

    // The Scene Manager is referenced & loads Intro scene by string/name
    public void GoToInto()
    {
        AudioManager.Instance?.PlayMenuClick();
        SceneManager.LoadScene("Intro"); 
    }

    // The Scene Manager is referenced & loads Tutorial Scene by string/name
    public void GoToTutorial()
    {
        AudioManager.Instance?.PlayMenuClick();
        SceneManager.LoadScene("TutorialScene"); 
    }

    // The Scene Manager is referenced & loads Main Menu scene by string/name
    public void GoToMainMenu()
    {
        AudioManager.Instance?.PlayMenuClick();
        SceneManager.LoadScene("MainMenu"); 
    }

    // The Scene Manager is referenced & loads Credits Screen scene by string/name
    public void GoToCredits()
    {
        AudioManager.Instance?.PlayMenuClick();
        SceneManager.LoadScene("CreditsScreen"); 
    }

    // This function quits the game & application
    public void QuitGame()
    {
        AudioManager.Instance?.PlayMenuClick();
        Application.Quit();
    }
}
