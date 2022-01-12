using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;

	public AudioSource music;
	public AudioSource sfx;

	public AudioClip mainMenuMusic;
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
		if( music.clip != mainMenuMusic )
		{
			music.clip = mainMenuMusic;
			music.volume = 0.389f;
			music.Play();
		}
	}

	public void PlayGameplayMusic()
	{
		if( music.clip != gameplayMusic )
		{
			music.clip = gameplayMusic;
			music.volume = 0.25f;
			music.Play();
		}
	}

	public void PlayEndingMusic()
	{
		if( music.clip != endingMusic )
		{
			music.clip = endingMusic;
			music.volume = 0.5f;
			music.Play();
		}
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