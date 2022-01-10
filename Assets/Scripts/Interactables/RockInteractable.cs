using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RockInteractable : TransformInteractable
{
	public ItemData pickaxe;

	public TextMeshProUGUI selectedText;

	public override void Select()
	{
		base.Select();

		if( PlayerController.instance.inventory.Contains( pickaxe ) )
		{
			selectedText.SetText( "Press Space to Smash the Rock!");
		}
		else
		{
			selectedText.SetText( "You need a Pickaxe to Smash the Rock!" );
		}
		
	}

	public override void OnInteract()
	{
		if( PlayerController.instance.inventory.Contains( pickaxe ) )
		{
			base.OnInteract();

			DisableCollider();

			PlayerController.instance.inventory.Remove( pickaxe );
		}
	}
}
