using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GateInteractable : TransformInteractable
{
	public ItemData key;
	public TextMeshProUGUI selectedText;

	public override void Select()
	{
		base.Select();

		if( PlayerController.instance.inventory.Contains( key ) )
		{
			selectedText.SetText( "Press Space to Unlock Gate!");
		}
		else
		{
			selectedText.SetText( "You can't unlock this!" );
		}
		
	}

	public override void OnInteract()
	{
		if( PlayerController.instance.inventory.Contains( key ) )
		{
			base.OnInteract();

			DisableCollider();

			PlayerController.instance.inventory.Remove( key );
		}
	}
}
