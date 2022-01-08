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

    private List<Interactable> nearbyInteractableList;
    private Interactable closestInteractable;
    private Interactable previousInteractable;

    // Awake is called before the first frame update
    // Awake is used for local initializations (on the same gameObject)
    private void Awake()
    {
        instance = this;
        character = GetComponent<CharacterController>();

        nearbyInteractableList = new List<Interactable>();
    }

    private void Update()
    {
        // Moves the player based on how much was specified in OnMovement()
        character.SimpleMove(moveVector);

        FindClosestInteractable();
    }

    private void OnInteract()
    {
        if( closestInteractable )
        {
            closestInteractable.OnInteract();
            closestInteractable.Deselect();
        }
    }

    // Extracts how fast and what direction to move the player
    private void OnMovement(InputValue value)
    {
        Vector2 InputDirection = value.Get<Vector2>();
        Vector3 MoveDirection = new Vector3(InputDirection.x, 0, InputDirection.y);
        
        moveVector = MoveSpeed * MoveDirection;
    }

    // This function is used when the Player collider hits another collider.
    // Will be called when it hits the ground
    // Want a certain behavior to be triggered when the object is tagged as an item
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Item")
        {
            // After Destroy, the item is collected. 
            Destroy(collision.gameObject);
            PresentManager.instance.AddPresent();
        }
        else if( collision.tag == "Interactable" )
        {
            Interactable interactable = collision.GetComponent<Interactable>();
            nearbyInteractableList.Add( interactable );
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if( collision.tag == "Interactable" )
        {
            Interactable interactable = collision.GetComponent<Interactable>();
            if( nearbyInteractableList.Contains( interactable ) )
            {
                nearbyInteractableList.Remove( interactable );
            }
            else
            {
                Debug.LogWarning("Tried to remove interactable but none found!");
            }
        }
    }

    private void FindClosestInteractable()
    {
        // Sort all interactables within radius by distance
        closestInteractable = null;
        float closestDistance = float.PositiveInfinity;
        foreach (Interactable interactable in nearbyInteractableList)
        {
            float distance = Vector3.Distance( transform.position, interactable.transform.position );
            if(distance < closestDistance) 
            {
                closestDistance = distance;
                closestInteractable = interactable;
            }
        }

        // If there is a close interactable, then tell Interactable
        if( closestInteractable )
        {
            closestInteractable.Select();
        }

        // If our closest Interactable was not our closest from the previous tick
        if( previousInteractable != closestInteractable )
        {
            previousInteractable?.Deselect();
            previousInteractable = closestInteractable;
        }
    }
}
