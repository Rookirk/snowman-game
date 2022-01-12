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

	public SkinnedMeshRenderer bucket;
	public SkinnedMeshRenderer rope;
	public Transform crank;

	private float ropeBlendValue = 0;
	private float bucketBlendValue = 0;

	private int score = 0;
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

	private void Update()
	{
		rope.SetBlendShapeWeight( 0, ropeBlendValue );
		bucket.SetBlendShapeWeight( 0, bucketBlendValue );
	}

	public override void OnInteract()
	{
		audioSource.Play();

		score++;
		DisableCollider();

		switch( score )
		{
			case 1:
				DOTween.To( () => ropeBlendValue, x => ropeBlendValue = x, 33f, duration );
				crank.DORotate( new Vector3(720, 0 , 0), duration, RotateMode.FastBeyond360 );
				StartCoroutine( ReEnableCollider() );
				break;
			
			case 2:
				DOTween.To( () => ropeBlendValue, x => ropeBlendValue = x, 66f, duration );
				crank.DORotate( new Vector3(1080, 0 , 0), duration, RotateMode.FastBeyond360 );
				StartCoroutine( ReEnableCollider() );
				break;

			case 3:
				DOTween.To( () => ropeBlendValue, x => ropeBlendValue = x, 100f, duration );
				DOTween.To( () => bucketBlendValue, x => bucketBlendValue = x, 100f, duration );
				crank.DORotate( new Vector3(1080, 0 , 0), duration, RotateMode.FastBeyond360 );
				StartCoroutine( ActivatePresent() );
				break;
		}
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( .95f * duration );

		present.transform.DOJump( destinationPosition, presentJumpHeight, 1, duration );

		yield return new WaitForSeconds( duration );

		present.Activate();
    }

	private IEnumerator ReEnableCollider()
	{
		yield return new WaitForSeconds( duration );

		EnableCollider();
	}
}
