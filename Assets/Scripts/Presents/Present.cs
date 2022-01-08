using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public Transform presentModel;
    public AudioClip pickupSound;
    private AudioSource source;

    // Vars for translation and rotation
    float floatMagnitude = 0.5f;
    float floatSpeed = 0.001f;
    float rotationSpeed = 0.05f;
    float n = 0.0f;
    bool collected = false;

    // Original transformation position
    Vector3 originalPos;

    // Float offset
    Vector3 floatOffset = new Vector3(0.0f, 0.0f, 0.0f);

    // Set original position of object
    void Start()
    {
        originalPos = presentModel.position;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (collected == false)
        {
            // Vertical float
            n += floatSpeed;
            floatOffset.y = Mathf.Sin(n) * floatMagnitude;
            presentModel.position = floatOffset + originalPos;

            // Rotation
            presentModel.Rotate(0.0f, rotationSpeed, 0.0f);
        }
        else
        {
            presentModel.Translate(0.0f, 0.03f, 0.0f);
            presentModel.Rotate(0.0f, rotationSpeed * 4, 0.0f);
        }
        
    }

    public void Collected()
    {
        collected = true;
        GetComponent<Collider>().enabled = false;

        // Play Sound
        source.Play();

        // Add item to present manager
        PresentManager.instance.AddItem();

        // Destroy this game object
        Destroy(gameObject, pickupSound.length);
    }
}
