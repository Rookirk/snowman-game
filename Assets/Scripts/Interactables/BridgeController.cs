using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BridgeController : Interactable
{
	public Bridge bridge;

	private int currentScore = -1;

	public override void OnInteract()
	{
		if( currentScore == -1 )
		{
			currentScore = 1;
		}
		else
		{
			currentScore = -1;
		}

		bridge.AdjustHeight( currentScore );
	}
}