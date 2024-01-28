using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
        public float speed;
        public float freq;
        
        void FixedUpdate()
        {
                transform.position += new Vector3(-speed, Mathf.Sin(Time.time * freq * Mathf.PI), 0);
        }
}

