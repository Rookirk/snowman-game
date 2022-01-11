using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TimedDoorLock : Interactable
{
	public TimedDoor door;

	public override void OnInteract()
	{
		door.Lock();
		DisableCollider();
	}
}