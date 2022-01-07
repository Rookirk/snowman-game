using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    CharacterController character;

    public float MoveSpeed;
    public int itemsCollected = 3;

    private Vector3 moveVector;

    // Awake is called before the first frame update
    // Awake is used for local initializations (on the same gameObject)
    void Awake()
    {
        instance = this;
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        character.SimpleMove(moveVector);
    }

    void OnMovement(InputValue value)
    {
        Vector2 InputDirection = value.Get<Vector2>();
        Vector3 MoveDirection = new Vector3(InputDirection.x, 0, InputDirection.y);
        
        moveVector = MoveSpeed * MoveDirection;
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
            itemManager.instance.AddItem();
        }
    }
}
