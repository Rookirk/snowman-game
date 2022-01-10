using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
	public Action OnPress;
	public Action OnRelease;

	private void OnTriggerEnter( Collider other )
	{
		if( other.tag == "Player" )
		{
			OnPress?.Invoke();
		}
	}

	private void OnTriggerExit( Collider other )
	{
		if( other.tag == "Player" )
		{
			OnRelease?.Invoke();
		}
	}
}