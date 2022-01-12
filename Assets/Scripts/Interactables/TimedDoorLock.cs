using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TimedDoorLock : TransformInteractable
{
	public TimedDoor door;
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public override void OnInteract()
	{
		base.OnInteract();
		
		audioSource.Play();
		door.Lock();
		DisableCollider();
	}
}