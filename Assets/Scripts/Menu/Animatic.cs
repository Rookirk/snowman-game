using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Animatic : MonoBehaviour
{
    public string NextLoadingScene;
    public Image display;
    public List<Sprite> images;
    public TextMeshProUGUI continueText;

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
        else if( currImageIndex == images.Count - 1 )
        {
            continueText.enabled = false;
        }

        display.sprite = images[ currImageIndex ];
        display.rectTransform.sizeDelta = images[ currImageIndex ].bounds.size * 100;
    }
}