using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlidingInteractable : Interactable
{
	public override void OnInteract()
	{
		Debug.Log("I have been Interacted!");
	}
}