using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData data;
    public bool activateOnStart = true;

	private Collider detectionCollider;

	private bool inInventory = false;
	private float maxDistanceFromPlayer;

	public Transform model;

    // Vars for translation and rotation
    public float floatMagnitude = 0.5f;
    public float floatSpeed = 1f;
    public float rotationSpeed = 25f;
    public float liftSpeed = 1f;

    private float floatCount = 0.0f;

	private bool shouldAnimate = true;

	protected virtual void Awake()
	{
		if( data == null )
		{
			Debug.LogError($"{name} doesn't have data specified!");
		}

		detectionCollider = GetComponent<Collider>();
	}

	protected virtual void Start()
	{
		if( !activateOnStart )
        {
            detectionCollider.enabled = false;
			shouldAnimate = false;
        }
	}

	private void Update()
	{
		if( inInventory )
		{
			Vector3 playerPosition = PlayerController.instance.transform.position;
			float distanceToPlayer = Vector3.Distance( transform.position, playerPosition );
			if( distanceToPlayer > maxDistanceFromPlayer )
			{
				Vector3 newHorizontalPosition = Vector3.MoveTowards( transform.position, playerPosition, PlayerController.instance.MoveSpeed * Time.deltaTime );

				transform.position = newHorizontalPosition;
			}
		}

		if( shouldAnimate )
		{
			// Vertical float
			Vector3 newVerticalPosition = model.localPosition;

			floatCount += floatSpeed * Time.deltaTime;
			newVerticalPosition.y = ( -Mathf.Cos(floatCount) + 1 ) * floatMagnitude;
			model.localPosition = newVerticalPosition;

			// Rotation
			model.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
		}
	}

	public void Activate()
	{
		detectionCollider.enabled = true;
		shouldAnimate = true;
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
