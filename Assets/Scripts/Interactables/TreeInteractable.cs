using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeInteractable : Interactable
{
	public Present present;
	private Animator animator;

	private AudioSource treeAudioSource;
	public AudioSource presentAudioSource;

	public float duration = 1.2f;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		treeAudioSource = GetComponent<AudioSource>();
	}

	public override void OnInteract()
	{
		animator.SetTrigger("Shake");
		treeAudioSource.Play();

		DisableCollider();

		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( duration );

		present.Activate();
		presentAudioSource.Play();
    }
}