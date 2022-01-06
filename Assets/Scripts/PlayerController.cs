using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    CharacterController character;

    public float MoveSpeed;

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
}
