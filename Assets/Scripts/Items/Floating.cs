using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public Transform model;

    // Vars for translation and rotation
    public float floatMagnitude = 0.5f;
    public float floatSpeed = 1f;
    public float rotationSpeed = 1f;
    public float liftSpeed = 1f;

    private float floatCount = 0.0f;

    // Update is called once per frame
    void Update()
    {
        // Vertical float
        Vector3 newPosition = model.localPosition;

        floatCount += floatSpeed * Time.deltaTime;
        newPosition.y = ( -Mathf.Cos(floatCount) + 1 ) * floatMagnitude;
        model.localPosition = newPosition;

        // Rotation
        model.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
    }
}
