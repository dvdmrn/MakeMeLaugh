using System.Collections;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    public GameObject targetObject; // The object to move
    public Vector3 targetPosition = new Vector3(1.0f, 2.0f, 3.0f); // Target position
    public Quaternion targetRotation = Quaternion.identity; // Target rotation

    public float moveSpeed = 2.0f; // Adjust the speed as needed

    private int clickCount = 0;
    private Vector3 initialPosition;

    private void Start()
    {
        // Get the initial position when the script starts
        if (targetObject != null)
        {
            initialPosition = targetObject.transform.position;
        }
    }

    private void OnMouseDown()
    {
        clickCount++;

        if (clickCount % 2 == 0)
        {
            // If the click count is a multiple of 3, move the object to its initial position
            MoveObjectToInitialPosition();
        }
        else
        {
            // Otherwise, move the object to the target position
            MoveObjectToTarget();
        }
    }

    private void MoveObjectToTarget()
    {
        if (targetObject != null)
        {
            StartCoroutine(MoveObjectCoroutine(targetPosition, targetRotation));
        }
    }

    private void MoveObjectToInitialPosition()
    {
        if (targetObject != null)
        {
            StartCoroutine(MoveObjectCoroutine(initialPosition, Quaternion.identity));
        }
    }

    private IEnumerator MoveObjectCoroutine(Vector3 destinationPosition, Quaternion destinationRotation)
    {
        float elapsedTime = 0f;
        Vector3 initialRotationEulerAngles = targetObject.transform.eulerAngles;

        while (elapsedTime < 1f)
        {
            targetObject.transform.position = Vector3.Lerp(targetObject.transform.position, destinationPosition, elapsedTime);
            targetObject.transform.rotation = Quaternion.Lerp(Quaternion.Euler(initialRotationEulerAngles), destinationRotation, elapsedTime);

            elapsedTime += Time.deltaTime * moveSpeed;
            yield return null;
        }

        // Ensure the object reaches the exact target position and rotation
        targetObject.transform.position = destinationPosition;
        targetObject.transform.rotation = destinationRotation;
    }
}
