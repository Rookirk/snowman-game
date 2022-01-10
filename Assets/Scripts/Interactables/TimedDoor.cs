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

	private Tween previousPositionTween;
	private Vector3 loweredPosition;
	private Vector3 raisedPosition;

	private void Start()
	{
		plate.OnPress += Raise;
		plate.OnRelease += Lower;

		loweredPosition = movingDoor.position;
		raisedPosition = raisedDoor.position;
	}

	private void Raise()
	{
		previousPositionTween?.Kill();
		previousPositionTween = movingDoor.DOMove( raisedPosition, 1f );
	}

	private void Lower()
	{
		previousPositionTween?.Kill();
		previousPositionTween = movingDoor.DOMove( loweredPosition, 5f );
	}

	private void Lock()
	{
		Raise();

		plate.OnPress -= Raise;
		plate.OnRelease -= Lower;
	}
}