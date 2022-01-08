using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public Transform presentModel;
    public AudioClip pickupSound;
    private AudioSource source;

    // Vars for translation and rotation
    public float floatMagnitude = 0.5f;
    public float floatSpeed = 1f;
    public float rotationSpeed = 1f;
    public float liftSpeed = 1f;

    private float floatCount = 0.0f;
    private bool collected = false;

    // Original transformation position
    private Vector3 originalPos;

    // Float offset
    private Vector3 floatOffset = new Vector3(0.0f, 0.0f, 0.0f);

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
            floatCount += floatSpeed * Time.deltaTime;
            floatOffset.y = Mathf.Sin(floatCount) * floatMagnitude;
            presentModel.position = floatOffset + originalPos;

            // Rotation
            presentModel.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }
        else
        {
            presentModel.Translate(0.0f, liftSpeed * Time.deltaTime, 0.0f);
            presentModel.Rotate(0.0f, rotationSpeed * 10 * Time.deltaTime, 0.0f);
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
