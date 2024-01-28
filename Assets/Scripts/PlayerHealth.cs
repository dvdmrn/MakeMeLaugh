using System.Collections;
using System.Collections.Generic;
using OpenCvSharp.Util;
using UnityEngine;

public delegate void OnTakeDamage();

public class PlayerHealth : MonoBehaviour
{
    public static event Action TakeDamage;
    public static event Action TakeSmiles;

    public void OnTakingDamage()
    {
        print("in on taking damage");
        TakeDamage?.Invoke();
    }

    public void OnSmile()
    {
        if (FaceDetector.isSmiling)
        {
            TakeSmiles?.Invoke();
        } else {
            TakeDamage?.Invoke();
        }


    }
    public void OnDoNotSmile()
    {
        if (FaceDetector.isSmiling)
        {
            TakeDamage?.Invoke();
        } else {
            TakeSmiles?.Invoke();
        }


    }


    private void OnTriggerEnter(Collider other)
    {
    print($"collided with: {other}");
    if(other.gameObject.tag == "Enemy") {
        OnTakingDamage();
    }
    if(other.gameObject.tag == "Smile") {
        OnSmile();
    } 
    if(other.gameObject.tag == "Frown") {
        OnDoNotSmile();
    }
    }

}