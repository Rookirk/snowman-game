using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    float currTime = 0f; // Current Time starts at 0 seconds
    float startTime = 12f; // Starting Time starts at 12 seconds (for "Intro" scene)
    public string NextLoadingScene; // Next scene to load

    // SerializeField: Similar to private, but can view in the Inspector
    [SerializeField] Text countdownText;

    // For initialization: Set current time to starting time 
    void Start () 
    {
        // This is for "TutorialScene": Set Starting Time to 9 seconds instead
        if (NextLoadingScene == "SnowScene")
        {
            startTime = 9f; 
        }  

        currTime = startTime;
    }
        
    // Update is called once per frame
    void Update () 
    {
        // Decrease the timer by 1 for each second 
        currTime -= 1 * Time.deltaTime;

        // Display the text of the timer
        countdownText.text = currTime.ToString("0");

        // When the current time reaches 0, 
        // set the current time equal to 0 (stop turning negative) & load the next scene
        if (currTime <= 0)
        {
            currTime = 0;
            SceneManager.LoadScene(NextLoadingScene);
        }

    }
}
