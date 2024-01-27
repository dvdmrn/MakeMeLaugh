using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    public float scrollSpeed; // units/s tos scroll
    private Rigidbody _rb; // using a rb for more precision

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // print($"t: {Time.realtimeSinceStartup} | x: {transform.position.x} | ratio:{Time.realtimeSinceStartup/transform.position.x}");
        // transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0, 0);
        _rb.velocity = new Vector3(-scrollSpeed, 0, 0); // moves at scrollSpeed per sec
    }
}
