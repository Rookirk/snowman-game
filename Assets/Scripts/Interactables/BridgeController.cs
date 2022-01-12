using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BridgeController : TransformInteractable
{
	public Bridge bridge;
	private AudioSource audioSource;

	public AudioClip onSound;
	public AudioClip offSound;

	private int currentScore = -1;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public override void OnInteract()
	{
		base.OnInteract();
		
		if( currentScore == -1 )
		{
			currentScore = 1;
			audioSource.clip = onSound;
		}
		else
		{
			currentScore = -1;
			audioSource.clip = offSound;
		}

		audioSource.Play();
		bridge.AdjustHeight( currentScore );
	}
}