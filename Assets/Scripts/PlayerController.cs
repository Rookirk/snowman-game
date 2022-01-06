using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController character;

    // Start is called before the first frame update
    void Awake()
    {
        character = GetComponent<CharacterController>();
    }

    void OnMovement(Vector2 direction)
    {
        character.Move(direction);
    }
}
