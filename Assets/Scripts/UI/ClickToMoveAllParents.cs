using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMoveAllParents : MonoBehaviour
{
    public float clickDistance = 0.1f;

    void OnMouseDown()
    {
        // Move the object downward when clicked
        MoveObject(transform, Vector3.down * clickDistance);
    }

    void MoveObject(Transform objTransform, Vector3 offset)
    {
        Rigidbody rb = objTransform.GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            rb.MovePosition(objTransform.position + offset);
        }
        else
        {
            objTransform.Translate(offset);
        }

        // Move all parents recursively
        Transform parentTransform = objTransform.parent;
        while (parentTransform != null)
        {
            Rigidbody parentRb = parentTransform.GetComponent<Rigidbody>();
            if (parentRb != null && !parentRb.isKinematic)
            {
                parentRb.MovePosition(parentTransform.position + offset);
            }
            else
            {
                parentTransform.Translate(offset);
            }

            parentTransform = parentTransform.parent;
        }
    }
}