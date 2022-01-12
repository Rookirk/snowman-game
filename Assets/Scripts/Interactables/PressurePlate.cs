using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
	public Action OnPress;
	public Action OnRelease;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter( Collider other )
	{
		if( other.tag == "Player" )
		{
			audioSource.pitch = .8f;
			audioSource.Play();
			OnPress?.Invoke();
		}
	}

	private void OnTriggerExit( Collider other )
	{
		if( other.tag == "Player" )
		{
			audioSource.pitch = 1f;
			audioSource.Play();
			OnRelease?.Invoke();
		}
	}
}