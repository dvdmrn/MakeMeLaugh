using System.Collections;
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

        // Start a coroutine to move the object back to its original position after 2 seconds
        StartCoroutine(MoveBackAfterDelay());
    }

    private IEnumerator MoveBackAfterDelay()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(0.2f);

        // Move the object back to its original position
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null && !rb.isKinematic)
        {
            rb.MovePosition(transform.position - Vector3.down * clickDistance);
        }
        else
        {
            transform.Translate(Vector3.up * clickDistance); // Move it back up
        }
    }
}
