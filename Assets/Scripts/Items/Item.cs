using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;
	private Collider detectionCollider;

	private bool inInventory = false;
	private float maxDistanceFromPlayer;

	protected virtual void Awake()
	{
		if( data == null )
		{
			Debug.LogError($"{name} doesn't have data specified!");
		}

		detectionCollider = GetComponent<Collider>();
	}

	private void Update()
	{
		if( inInventory )
		{
			Vector3 playerPosition = PlayerController.instance.transform.position;
			float distanceToPlayer = Vector3.Distance( transform.position, playerPosition );
			if( distanceToPlayer > maxDistanceFromPlayer )
			{
				Vector3 newPosition = Vector3.MoveTowards( transform.position, playerPosition, PlayerController.instance.MoveSpeed * Time.deltaTime );

				transform.position = newPosition;
			}
		}
	}

	public void FollowPlayer( float maxDistanceFromPlayer )
	{
		detectionCollider.enabled = false;
		inInventory = true;
		this.maxDistanceFromPlayer = maxDistanceFromPlayer;
	}

	public void Remove()
	{
		inInventory = false;
		Destroy(gameObject);
	}
}
