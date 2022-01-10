using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<Item> inventory;

	public float distanceBetweenItems = 1f;

	private void Awake()
	{
		inventory = new List<Item>();
	}

	public bool Contains( ItemData item )
	{
		foreach( Item currItem in inventory )
		{
			if( currItem.data == item )
			{
				return true;
			}
		}

		return false;
	}

	public void Add( Item item )
	{
		inventory.Add( item );
		item.FollowPlayer( distanceBetweenItems * ( inventory.IndexOf( item ) + 1 ) );
	}

	public void Remove( Item item )
	{
		if( inventory.Contains( item ) )
		{
			inventory.Remove( item );
			item.Remove();
		}
		else
		{
			Debug.LogWarning( "Tried removing an item, but couldn't!" );
			return;
		}

		foreach( Item currItem in inventory )
		{
			currItem.FollowPlayer( distanceBetweenItems * ( inventory.IndexOf( currItem ) + 1 ) );
		}
	}

	public void Remove( ItemData item )
	{
		foreach( Item currItem in inventory )
		{
			if( currItem.data == item )
			{
				Remove( currItem );
				return;
			}
		}
		Debug.LogWarning( "Tried removing an item, but couldn't!" );
	}
}
