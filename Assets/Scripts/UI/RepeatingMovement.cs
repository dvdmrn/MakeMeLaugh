using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingMovement : MonoBehaviour
{
    public GameObject prefabToInstantiate; // Prefab of the object to be instantiated
    public float moveSpeed = 1f;  // Adjust the speed as needed
    public float moveDistance = 10f;  // Adjust the distance as needed

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        float step = moveSpeed * Time.deltaTime;

        // Move the object along the X-axis
        transform.Translate(Vector3.right * step);

        // Calculate the absolute distance traveled
        float absoluteDistance = Mathf.Abs(transform.position.x - initialPosition.x);

        // Check if the object reached the destination
        if (absoluteDistance >= moveDistance)
        {
            // Instantiate a new instance of the script
            Instantiate(prefabToInstantiate, initialPosition, Quaternion.Euler(90f, 0f, 0f));

            // Destroy the original instance
            Destroy(gameObject);
        }
    }
}