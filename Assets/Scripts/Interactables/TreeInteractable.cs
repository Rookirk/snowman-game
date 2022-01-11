using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeInteractable : Interactable
{
	public Present present;
	private Animator animator;

	public float duration = 1.2f;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public override void OnInteract()
	{
		animator.SetTrigger("Shake");

		DisableCollider();

		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( duration );

		present.Activate();
    }
}