using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeInteractable : Interactable
{
	public Present present;
	private Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	public override void OnInteract()
	{
		animator.SetTrigger("Shake");

		Deselect();
		GetComponent<Collider>().enabled = false;

		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( 2f );

		present.Activate();
    }
}