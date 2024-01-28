using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed
    public float resetPosition = 20f; // Adjust this based on your scene
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        // Move the object horizontally
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        // Check if the object is out of camera range
        if (IsObjectOutOfCamera())
        {
            // Reset position when the object goes beyond a certain point
            transform.position = new Vector3(-resetPosition, transform.position.y, transform.position.z);
        }
    }

    bool IsObjectOutOfCamera()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the object is outside the camera's view
        return viewportPosition.x > 1;
    }
}