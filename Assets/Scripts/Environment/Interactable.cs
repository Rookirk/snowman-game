using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// TODO: Theoretically can be triggered multiple times.
// Will need to track that?
public abstract class Interactable : MonoBehaviour
{
	public abstract void Select();
	public abstract void Deselect();

	public abstract void OnInteract();
}