using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestInteractable : TransformInteractable
{
	public Item item;

	public Transform itemMidpoint;
	public Transform itemDestination;

	private Vector3 itemDestinationPosition;
	private float itemJumpHeight;
	private Tween itemPositionTween;

	protected override void Start()
	{
		base.Start();

		itemDestinationPosition = itemDestination.position;
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

		item.transform.DOJump( itemDestinationPosition, itemJumpHeight, 1, duration );

		StartCoroutine( ActivateItem() );
	}

    private IEnumerator ActivateItem()
    {
        yield return new WaitForSeconds( duration );

		item.Activate();
    }
}
