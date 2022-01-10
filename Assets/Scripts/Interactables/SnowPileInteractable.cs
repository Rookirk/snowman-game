using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnowPileInteractable : TransformInteractable
{
	public Present present;

	public override void OnInteract()
	{
		base.OnInteract();

		DisableCollider();

		StartCoroutine( ActivatePresent() );
	}

    private IEnumerator ActivatePresent()
    {
        yield return new WaitForSeconds( Mathf.Max( duration - .5f, 0f ) );

		present.Activate();
    }
}
