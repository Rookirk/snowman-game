using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bridge : MonoBehaviour
{
	public Transform bridge;
	public Transform slightlyRaisedBridge;
	public Transform loweredBridge;
	public float duration = 1;

	private Quaternion raisedRotation;
	private Quaternion slightlyRaisedRotation;
	private Quaternion loweredRotation;

	private int currentPosition = 0;
	private Tween previousRotationTween;

	private Coroutine previousCoroutine;
	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void Start()
	{
		raisedRotation = bridge.rotation;
		slightlyRaisedRotation = slightlyRaisedBridge.rotation;
		loweredRotation = loweredBridge.rotation;

		slightlyRaisedBridge.gameObject.SetActive(false);
		loweredBridge.gameObject.SetActive(false);
	}

	public void SetHeight()
	{
		previousRotationTween?.Kill();
		if( previousCoroutine != null )
		{
			StopCoroutine( previousCoroutine );
		}

		switch( currentPosition )
		{
			case 0:
				previousRotationTween = bridge.DORotateQuaternion( raisedRotation, duration );
				break;

			case 1:
				previousRotationTween = bridge.DORotateQuaternion( slightlyRaisedRotation, duration );
				break;

			case 2:
				previousCoroutine = StartCoroutine( PlaySound() );
				previousRotationTween = bridge.DORotateQuaternion( loweredRotation, duration );
				break;
			
			default:
				Debug.LogWarning( $"{gameObject.name} tried to tween from {currentPosition} but couldn't" );
				break;
		}
	}

	public void AdjustHeight( int amount )
	{
		currentPosition += amount;

		SetHeight();
	}

	private IEnumerator PlaySound()
	{
		yield return new WaitForSeconds( duration );

		audioSource.Play();
	}
}