using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScroll : MonoBehaviour
{
    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        print("scroll active!");
    }

    // Update is called once per frame
    void Update()
    {
        print("scrollin");
        // transform.position = new Vector3(100, 100, 100);
        transform.position += new Vector3(-scrollSpeed, 0, 0);
    }
}
