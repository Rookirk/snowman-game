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

    // Set original position of object
    void Start()
    {
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
                // As a note to Bryson, I removed floatOffset because it hardcoded the x and z coordinates to 0,0
                Vector3 newPosition = presentModel.localPosition;

                floatCount += floatSpeed * Time.deltaTime;
                newPosition.y = ( -Mathf.Cos(floatCount) + 1 ) * floatMagnitude;
                presentModel.localPosition = newPosition;

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
    }

    public void Collected()
    {
        collected = true;
        detectionCollider.enabled = false;

        // Play Sound
        AudioManager.Instance?.PlayPresentCollect();

        // Add item to present manager
        PresentManager.instance.AddPresent();

        // Destroy this game object
        Destroy(gameObject, source.clip.length);
    }
}
