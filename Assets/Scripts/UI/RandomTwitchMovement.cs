using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTwitchMovement : MonoBehaviour
{
    public Vector3 moveDistance = new Vector3(1.0f, 1.0f, 1.0f);
    public float moveSpeed = 1.0f;
    public float minInterval = 4.0f;
    public float maxInterval = 10.0f;

    private Vector3 originalPosition;
    private bool isMoving = false;

    void Start()
    {
        originalPosition = transform.position;
        StartCoroutine(RandomMovementCoroutine());
    }

    IEnumerator RandomMovementCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));

            // Calculate a random target position within the specified move distance
            Vector3 randomOffset = new Vector3(Random.Range(-moveDistance.x, moveDistance.x), Mathf.Abs(Random.Range(0, moveDistance.y)), Random.Range(-moveDistance.z, moveDistance.z));
            Vector3 targetPosition = originalPosition + randomOffset;

            // Move to the target position
            yield return StartCoroutine(MoveObject(transform.position, targetPosition, moveSpeed));

            // Move back to the original position
            yield return StartCoroutine(MoveObject(targetPosition, originalPosition, moveSpeed));
        }
    }

    IEnumerator MoveObject(Vector3 startPosition, Vector3 targetPosition, float speed)
    {
        if (!isMoving)
        {
            isMoving = true;

            float t = 0.0f;
            while (t < 1.0f)
            {
                t += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                yield return null;
            }

            isMoving = false;
        }
    }
}