using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TransformInteractable : Interactable
{
	public Transform movingObject;
	public Transform destination;
	public float duration = 1;

	private Vector3 sourcePosition;
	private Quaternion sourceRotation;
	private Vector3 sourceScale;

	private Vector3 destinationPosition;
	private Quaternion destinationRotation;
	private Vector3 destinationScale;

	private Position currentPosition = Position.SOURCE;
	private Tween previousPositionTween;
	private Tween previousRotationTween;
	private Tween previousScaleTween;

	protected override void Start()
	{
		base.Start();

		sourcePosition = movingObject.position;
		sourceRotation = movingObject.rotation;
		sourceScale = movingObject.localScale;

		destinationPosition = destination.position;
		destinationRotation = destination.rotation;
		destinationScale = destination.localScale;

		destination.gameObject.SetActive(false);
	}

	public override void OnInteract()
	{
		previousPositionTween?.Kill();
		previousRotationTween?.Kill();
		previousScaleTween?.Kill();

		switch( currentPosition )
		{
			case Position.SOURCE:
				previousPositionTween = movingObject.DOMove( destinationPosition, duration );
				previousRotationTween = movingObject.DORotateQuaternion( destinationRotation, duration );
				previousScaleTween = movingObject.DOScale( destinationScale, duration );
				currentPosition = Position.DESTINATION;
				break;

			case Position.DESTINATION:
				previousPositionTween = movingObject.DOMove( sourcePosition, duration );
				previousRotationTween = movingObject.DORotateQuaternion( sourceRotation, duration );
				previousScaleTween = movingObject.DOScale( sourceScale, duration );
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