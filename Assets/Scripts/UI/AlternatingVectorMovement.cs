using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingVectorMovement : MonoBehaviour

{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float timeLimit = 1.75f;
    [SerializeField] private float time = 0f;
    [SerializeField] private Vector2 direction = new Vector2(1, 0); // Default is horizontal movement

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        rb.velocity = speed * direction;
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeLimit)
        {
            // Reverse the direction by multiplying each component by -1
            direction = new Vector2(-direction.x, -direction.y);
            rb.velocity = speed * direction;
            time = 0f;
        }
    }
}

