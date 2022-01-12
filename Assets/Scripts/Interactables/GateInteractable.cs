using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class GateInteractable : TransformInteractable
{
	public ItemData key;
	public TextMeshProUGUI selectedText;
	public Transform Gate2;
	public Transform Gate2Open;

	private Quaternion destination2Rotation;

	private AudioSource audioSource;

	private void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}

	protected override void Start()
	{
		base.Start();

		destination2Rotation = Gate2Open.rotation;
		Gate2Open.gameObject.SetActive(false);
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

			Gate2.DORotateQuaternion( destination2Rotation, duration );

			DisableCollider();

			PlayerController.instance.inventory.Remove( key );
		}
	}
}
