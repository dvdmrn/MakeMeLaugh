using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject targetObject; // The object to move
    public Vector3 targetPosition = new Vector3(1.0f, 2.0f, 3.0f); // Target position
    public Quaternion targetRotation = Quaternion.identity; // Target rotation

    public float moveSpeed = 2.0f; // Adjust the speed as needed

    private void OnMouseDown()
    {
        MoveObjectToTarget();
    }

    private void MoveObjectToTarget()
    {
        if (targetObject != null)
        {
            StartCoroutine(MoveObjectCoroutine());
        }
    }

    private System.Collections.IEnumerator MoveObjectCoroutine()
    {
        float elapsedTime = 0f;
        Vector3 initialPosition = targetObject.transform.position;
        Quaternion initialRotation = targetObject.transform.rotation;

        while (elapsedTime < 1f)
        {
            targetObject.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime);
            targetObject.transform.rotation = Quaternion.Lerp(initialRotation, targetRotation, elapsedTime);

            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // Ensure the object reaches the exact target position and rotation
        targetObject.transform.position = targetPosition;
        targetObject.transform.rotation = targetRotation;
    }





    // public GameObject targetObject; // The object to move

    // // Specify the target position for ObjectB
    // public Vector3 targetPosition = new Vector3(1.0f, 2.0f, 3.0f);

    // private void OnMouseDown()
    // {
    //     MoveObjectToTarget();
    // }

    // private void MoveObjectToTarget()
    // {
    //     if (targetObject != null)
    //     {
    //         targetObject.transform.position = targetPosition;
    //     }
    // }
}