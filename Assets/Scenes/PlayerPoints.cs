using System.Collections;
using System.Collections.Generic;
using OpenCvSharp.Util;
using UnityEngine;

public class PlayerPoints : MonoBehaviour
{
    public static event Action TakeSmiles;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDE");
        if (FaceDetector.isSmiling)
        {
        Debug.Log("COLLIDE AND SMILE");
            // Call TakeSmiles event when there is a collision and the player is smiling
            TakeSmiles?.Invoke();
        }
    }
}
