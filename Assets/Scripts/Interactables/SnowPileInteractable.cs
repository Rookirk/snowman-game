using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnowPileInteractable : TransformInteractable
{
	public Present present;
	public Transform presentDestination;

	private Vector3 presentDestinationPosition;
	private Quaternion presentDestinationRotation;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	protected override void Start()
	{
		base.Start();

		presentDestinationPosition = presentDestination.position;
		presentDestinationRotation = presentDestination.rotation;
		presentDestination.gameObject.SetActive(false);
	}

	public override void OnInteract()
	{
		audioSource.Play();
		
		base.OnInteract();

		DisableCollider();

		present.transform.DOMove( presentDestinationPosition, duration );
		present.transform.DORotateQuaternion( presentDestinationRotation, duration );

		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( duration );

		present.Activate();
    }
}
