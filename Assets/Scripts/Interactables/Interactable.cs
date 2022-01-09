using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Interactable : MonoBehaviour
{
	public Canvas selectedCanvas;

	protected virtual void Start()
	{
		selectedCanvas.enabled = false;
	}

	/// <summary>
    /// Triggers behaviour to indicate this interactable is selectable
    /// </summary>
	public virtual void Select()
	{
		selectedCanvas.enabled = true;
	}

	/// <summary>
    /// Triggers behaviour to remove the select behaviour
    /// </summary>
	public virtual void Deselect()
	{
		selectedCanvas.enabled = false;
	}

	/// <summary>
    /// Triggers desired behaviour when player interacts with this object
    /// </summary>
	public abstract void OnInteract();

	public virtual void DisableCollider()
	{
		Deselect();
		GetComponent<Collider>().enabled = false;

		PlayerController.instance.RemoveFromInteractableList( this );
	}
}