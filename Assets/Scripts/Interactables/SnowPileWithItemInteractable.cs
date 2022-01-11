using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SnowPileWithItemInteractable : TransformInteractable
{
	public Item item;
	public Transform itemDestination;

	private Vector3 itemDestinationPosition;
	private Quaternion itemDestinationRotation;

	protected override void Start()
	{
		base.Start();

		itemDestinationPosition = itemDestination.position;
		itemDestinationRotation = itemDestination.rotation;
		itemDestination.gameObject.SetActive(false);
	}

	public override void OnInteract()
	{
		base.OnInteract();

		DisableCollider();

		item.transform.DOMove( itemDestinationPosition, duration );
		item.transform.DORotateQuaternion( itemDestinationRotation, duration );

		StartCoroutine( ActivateItem() );
	}

    private IEnumerator ActivateItem()
    {
        yield return new WaitForSeconds( duration );

		item.Activate();
    }
}
