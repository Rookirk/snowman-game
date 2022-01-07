using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    // Vars for translation and rotation
    float floatMagnitude = 0.5f;
    float floatSpeed = 0.001f;
    float rotationSpeed = 0.05f;
    float n = 0.0f;

    // Original transformation position
    Vector3 originalPos;

    // Float offset
    Vector3 floatOffset = new Vector3(0.0f, 0.0f, 0.0f);

    // Set original position of object
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Vertical float
        n += floatSpeed;
        floatOffset.y = Mathf.Sin(n) * floatMagnitude;
        transform.position = floatOffset + originalPos;

        // Rotation
        transform.Rotate(0.0f, rotationSpeed, 0.0f);
    }
}
