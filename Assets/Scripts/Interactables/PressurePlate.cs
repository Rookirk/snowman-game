using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
	public Action OnPress;
	public Action OnRelease;

	private void OnCollisionEnter( Collision collision )
	{
		if( collision.collider.tag == "Player" )
		{
			OnPress?.Invoke();
		}
	}

	private void OnCollisionExit( Collision collision )
	{
		if( collision.collider.tag == "Player" )
		{
			OnRelease?.Invoke();
		}
	}
}