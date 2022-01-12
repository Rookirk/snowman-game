using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateInteractable : TransformInteractable
{
	public ItemData key;
	public TextMeshProUGUI selectedText;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	public override void Select()
	{
		base.Select();

		if( PlayerController.instance.inventory.Contains( key ) )
		{
			selectedText.SetText( "Press Space to Unlock Gate!");
		}
		else
		{
			selectedText.SetText( "You need the key to Unlock this Gate!" );
		}
		
	}

	public override void OnInteract()
	{
		if( PlayerController.instance.inventory.Contains( key ) )
		{
			audioSource.Play();
			
			base.OnInteract();

			DisableCollider();

			PlayerController.instance.inventory.Remove( key );
		}
	}
}
