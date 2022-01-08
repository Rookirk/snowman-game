using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public Transform presentModel;
    public bool activateOnStart = true;

    private AudioSource source;
    private Collider detectionCollider;

    // Vars for translation and rotation
    public float floatMagnitude = 0.5f;
    public float floatSpeed = 1f;
    public float rotationSpeed = 1f;
    public float liftSpeed = 1f;

    private float floatCount = 0.0f;
    private bool collected = false;
    private bool shouldAnimate = true;

    // Original transformation position
    private Vector3 originalPos;

    // Float offset
    private Vector3 floatOffset = new Vector3(0.0f, 0.0f, 0.0f);

    // Set original position of object
    void Start()
    {
        // TODO: Redo this. Just have an offset gameObject determine the original position
        originalPos = presentModel.position;
        source = GetComponent<AudioSource>();
        detectionCollider = GetComponent<Collider>();

        if( !activateOnStart )
        {
            detectionCollider.enabled = false;
            shouldAnimate = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if( shouldAnimate )
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
    }

    public void Activate()
    {
        detectionCollider.enabled = true;
        shouldAnimate = true;
        originalPos = presentModel.position;
    }

    public void Collected()
    {
        collected = true;
        detectionCollider.enabled = false;

        // Play Sound
        source.Play();

        // Add item to present manager
        PresentManager.instance.AddItem();

        // Destroy this game object
        Destroy(gameObject, source.clip.length);
    }
}
