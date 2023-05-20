using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingCollectible : MonoBehaviour
{
    public float floatSpeed = 1f; // The speed of the floating motion
    public float floatHeight = 0.5f; // The height of the floating motion
    private Vector3 initialPosition; // The initial position of the collectible
    
    private void Awake()
    {
        initialPosition = transform.position;
    }
    
    private void Update()
    {
        // Calculate the new vertical position using a sine wave
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;

        // Update the collectible's position
        transform.position = new Vector3(initialPosition.x, newY, initialPosition.z);
    }

}
