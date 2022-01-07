using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Theoretically can be triggered multiple times.
// Will need to track that?
public abstract class Interactable : MonoBehaviour
{
	/// <summary>
    /// Triggers behaviour to indicate this interactable is selectable
    /// </summary>
	public abstract void Select();
	/// <summary>
    /// Triggers behaviour to remove the select behaviour
    /// </summary>
	public abstract void Deselect();

	/// <summary>
    /// Triggers desired behaviour when player interacts with this object
    /// </summary>
	public abstract void OnInteract();
}