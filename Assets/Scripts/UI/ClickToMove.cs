using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    public float clickDistance = 0.2f;

    void OnMouseDown()
    {
        // Move the object downward when clicked
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            rb.MovePosition(transform.position + Vector3.down * clickDistance);
        }
        else
        {
            transform.Translate(Vector3.down * clickDistance);
        }
    }
}