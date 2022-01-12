using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TreeInteractable : Interactable
{
	public Present present;
	private Animator animator;

	private AudioSource treeAudioSource;
	public AudioSource presentAudioSource;

	private ParticleSystem snowEffect;

	public float duration = 1.2f;

	private void Awake()
	{
		animator = GetComponent<Animator>();
		treeAudioSource = GetComponent<AudioSource>();
		snowEffect = GetComponent<ParticleSystem>();
	}

	public override void OnInteract()
	{
		animator.SetTrigger("Shake");
		treeAudioSource.Play();
		snowEffect.Play();

		DisableCollider();

		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( duration );

		present.Activate();
		presentAudioSource.Play();
		snowEffect.Stop();
    }
}