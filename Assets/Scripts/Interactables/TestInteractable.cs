using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestInteractable : Interactable
{
	public Canvas selectedText;

	private void Start()
	{
		selectedText.enabled = false;
	}

	public override void Select()
	{
		selectedText.enabled = true;
	}

	public override void Deselect()
	{
		selectedText.enabled = false;
	}

	public override void OnInteract()
	{
		Debug.Log("I have been Interacted!");
	}
}