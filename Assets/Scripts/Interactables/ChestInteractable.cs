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

	private AudioSource audioSource;

	// Audio
	private AudioSource chestOpen;
	private AudioSource snowmanSound;

	private void Awake()
	{
		List<AudioSource> chestSounds = new List<AudioSource>();
		GetComponents<AudioSource>(chestSounds);

		chestOpen = chestSounds[0];
		snowmanSound = chestSounds[1];
	}

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

		chestOpen.Play();
		snowmanSound.Play();

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
