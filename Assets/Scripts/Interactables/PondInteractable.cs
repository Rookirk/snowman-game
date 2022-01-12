using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PondInteractable : Interactable
{
	public Present present;

	public Transform presentMidPoint;
	public Transform presentDestination;

	private float presentJumpHeight;
	private Vector3 destinationPosition;

	public float duration = 1f;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	protected override void Start()
	{
		base.Start();

		destinationPosition = presentDestination.position;
		presentDestination.gameObject.SetActive(false);

		presentJumpHeight = presentMidPoint.position.y - present.transform.position.y;
		presentMidPoint.gameObject.SetActive(false);
	}

	public override void OnInteract()
	{
		audioSource.Play();
		DisableCollider();
		present.transform.DOJump( destinationPosition, presentJumpHeight, 1, duration );
		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( duration );

		present.Activate();
    }
}
