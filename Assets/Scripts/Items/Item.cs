using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;

	protected virtual void Awake()
	{
		if( data == null )
		{
			Debug.LogError($"{name} doesn't have data specified!");
		}
	}
}
