using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController character;

    public float MoveSpeed;
    public int itemsCollected = 0;

    // Start is called before the first frame update
    void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    void OnMovement(InputValue value)
    {
        Vector2 InputDirection = value.Get<Vector2>();
        Vector3 MoveDirection = new Vector3(InputDirection.x, 0, InputDirection.y);
        character.SimpleMove(MoveSpeed * MoveDirection);
    }

    // This function is used when the Player collider hits another collider.
    // Will be called when it hits the ground
    // Want a certain behavior to be triggered when the object is tagged as an item
    void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Item")
        {
            // After Destroy, the item is collected. 
            Destroy(collision.gameObject);
            itemsCollected++;
        }

    }
}
