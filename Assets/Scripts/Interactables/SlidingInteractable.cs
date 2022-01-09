using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SlidingInteractable : Interactable
{
	public Transform movingObject;
	public Transform destination;
	public float duration = 1;

	private Vector3 sourcePosition;
	private Vector3 destinationPosition;
	private Position currentPosition = Position.SOURCE;
	private Tween previousTween;

	protected override void Start()
	{
		base.Start();

		sourcePosition = movingObject.position;
		destinationPosition = destination.position;

		destination.gameObject.SetActive(false);
	}

	public override void OnInteract()
	{
		previousTween?.Kill();

		switch( currentPosition )
		{
			case Position.SOURCE:
				previousTween = movingObject.DOMove( destinationPosition, duration );
				currentPosition = Position.DESTINATION;
				break;

			case Position.DESTINATION:
				previousTween = movingObject.DOMove( sourcePosition, duration );
				currentPosition = Position.SOURCE;
				break;
			
			default:
				Debug.LogWarning( $"{gameObject.name} tried to tween from {currentPosition} but couldn't" );
				break;
		}
	}

	private enum Position
	{
		SOURCE,
		DESTINATION
	}
}