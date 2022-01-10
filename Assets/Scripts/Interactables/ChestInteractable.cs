using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestInteractable : TransformInteractable
{
	public Item item;

	public Transform itemMidpoint;
	public Transform itemDestination;

	private Vector3 destinationPosition;
	private float itemJumpHeight;
	private Tween destinationPositionTween;

	protected override void Start()
	{
		base.Start();

		destinationPosition = itemDestination.position;
		itemDestination.gameObject.SetActive(false);

		itemJumpHeight = itemMidpoint.position.y - item.transform.position.y;
		itemMidpoint.gameObject.SetActive(false);
	}

	public override void OnInteract()
	{
		base.OnInteract();

		DisableCollider();

		StartCoroutine( JumpItem() );
	}

	private IEnumerator JumpItem()
	{
		yield return new WaitForSeconds( duration/2 );

		item.transform.DOJump( destinationPosition, itemJumpHeight, 1, duration );

		StartCoroutine( ActivateItem() );
	}

    private IEnumerator ActivateItem()
    {
        yield return new WaitForSeconds( duration );

		item.Activate();
    }
}
