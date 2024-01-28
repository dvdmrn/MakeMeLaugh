using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingText3D : MonoBehaviour
{
    public float scrollSpeed = 5f; // Adjust the speed as needed
    public float resetPosition = 50f; // Adjust this based on your scene
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        ScrollText();
    }

    void ScrollText()
    {
        // Move the text horizontally
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Check if the text is out of camera range
        if (IsTextOutOfCamera())
        {
            // Reset position when text goes beyond a certain point
            transform.position = new Vector3(resetPosition, transform.position.y, transform.position.z);
        }
    }

    bool IsTextOutOfCamera()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check if the text is outside the camera's view
        return viewportPosition.x < 0 || viewportPosition.x > 1;
    }
}