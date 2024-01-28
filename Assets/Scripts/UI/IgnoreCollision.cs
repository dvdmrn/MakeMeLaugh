using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    public Rigidbody otherRigidbody;

    void Start()
    {
        // Ignore collision between this object's collider and the otherRigidbody's collider
        Physics.IgnoreCollision(GetComponent<Collider>(), otherRigidbody.GetComponent<Collider>());
    }
}