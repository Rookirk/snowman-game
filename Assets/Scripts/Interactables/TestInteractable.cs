using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestInteractable : Interactable
{
	public override void OnInteract()
	{
		Debug.Log("I have been Interacted!");
	}
}