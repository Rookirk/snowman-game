using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TimedDoor : MonoBehaviour
{
	public PressurePlate plate;

	public Transform movingDoor;
	public Transform raisedDoor;

	public float timeToRaise;
	public float timeToLower;

	private Tween previousPositionTween;
	private Vector3 loweredPosition;
	private Vector3 raisedPosition;

	// Audio
	private AudioSource doorOpen;
	private AudioSource doorClose;

	private void Start()
	{
		// Get Audio
		List<AudioSource> doorSounds = new List<AudioSource>();
		GetComponents<AudioSource>(doorSounds);

		doorOpen = doorSounds[0];
		doorClose = doorSounds[1];

		// Set positions
		plate.OnPress += Raise;
		plate.OnRelease += Lower;

		loweredPosition = movingDoor.position;
		raisedPosition = raisedDoor.position;

		raisedDoor.gameObject.SetActive(false);
	}

	private void Raise()
	{
		previousPositionTween?.Kill();
		previousPositionTween = movingDoor.DOMove( raisedPosition, timeToRaise );

		doorOpen.Play(); // Play sound effect
	}

	private void Lower()
	{
		previousPositionTween?.Kill();
		previousPositionTween = movingDoor.DOMove( loweredPosition, timeToLower );

		doorClose.Play(); // Play sound effect
	}

	public void Lock()
	{
		Raise();

		plate.OnPress -= Raise;
		plate.OnRelease -= Lower;
	}
}