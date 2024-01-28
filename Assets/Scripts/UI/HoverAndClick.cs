using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverAndClick : MonoBehaviour
{
    public float hoverDistance = 0.5f;
    public float hoverSpeed = 1.0f;
    public float clickDistance = 0.2f;

    private Vector3 originalPosition;
    private bool isHovering = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Hover the object when the mouse is over it
        if (isHovering)
        {
            float newY = originalPosition.y + Mathf.PingPong(Time.time * hoverSpeed, hoverDistance);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }

    void OnMouseOver()
    {
        isHovering = true;
    }

    void OnMouseExit()
    {
        isHovering = false;
        transform.position = originalPosition;
    }

    void OnMouseDown()
    {
        // Push the object downward when clicked
        transform.Translate(Vector3.down * clickDistance);
    }
}