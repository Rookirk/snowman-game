using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<ItemData> inventory;

	public bool Contains( ItemData item )
	{
		if( inventory.Contains( item ) )
		{
			return true;
		}

		return false;
	}

	public void Add( ItemData item )
	{
		inventory.Add( item );
	}

	public void Remove( ItemData item )
	{
		if( inventory.Contains( item ) )
		{
			inventory.Remove( item );
		}
		else
		{
			Debug.LogWarning( "Tried removing an item, but couldn't!" );
		}
	}
}
