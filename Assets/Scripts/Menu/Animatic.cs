using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Animatic : MonoBehaviour
{
    public string NextLoadingScene;
    public Image display;
    public List<Sprite> images;

    private int currImageIndex = 0;

    private void Start()
    {
        display.sprite = images[ currImageIndex ];
    }

	private void OnInteract()
    {
        currImageIndex++;

        if( currImageIndex >= images.Count )
        {
            SceneManager.LoadScene(NextLoadingScene);
        }

        display.sprite = images[ currImageIndex ];
    }
}