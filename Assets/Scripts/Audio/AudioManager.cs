using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	public AudioSource music;
	public AudioSource sfx;

	public AudioClip mainMenuMusic;
	public AudioClip introMusic;
	public AudioClip gameplayMusic;
	public AudioClip endingMusic;

	public AudioClip menuClick;
	public AudioClip presentCollect;

    protected void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        if (transform.parent == null)
		{
			DontDestroyOnLoad(gameObject);
		}
    }

	public void PlayMainMenuMusic()
	{
		music.clip = mainMenuMusic;
		music.Play();
	}

	public void PlayIntroMusic()
	{
		music.clip = introMusic;
		music.Play();
	}

	public void PlayGameplayMusic()
	{
		music.clip = gameplayMusic;
		music.volume = 0.25f;
		music.Play();
	}

	public void PlayEndingMusic()
	{
		music.clip = endingMusic;
		music.Play();
	}

	public void PlayMenuClick()
	{
		sfx.clip = menuClick;
		sfx.Play();
	}

	public void PlayPresentCollect()
	{
		sfx.clip = presentCollect;
		sfx.volume = .2f;
		sfx.Play();
	}
}