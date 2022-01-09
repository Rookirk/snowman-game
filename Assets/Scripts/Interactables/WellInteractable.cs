using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WellInteractable : Interactable
{
	public Present present;

	public Transform presentMidPoint;
	public Transform presentDestination;

	private float presentJumpHeight;
	private Vector3 destinationPosition;

	private int score = 0;
	public float duration = 1f;

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
		score++;
		DisableCollider();

		switch( score )
		{
			case 1:
				StartCoroutine( ReEnableCollider() );
				break;
			
			case 2:
				StartCoroutine( ReEnableCollider() );
				break;

			case 3:
				present.transform.DOJump( destinationPosition, presentJumpHeight, 1, duration );
				StartCoroutine( ActivatePresent() );
				break;
		}
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( duration );

		present.Activate();
    }

	private IEnumerator ReEnableCollider()
	{
		yield return new WaitForSeconds( duration );

		EnableCollider();
	}
}
