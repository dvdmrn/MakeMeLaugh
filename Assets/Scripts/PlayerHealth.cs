using System.Collections;
using System.Collections.Generic;
using OpenCvSharp.Util;
using UnityEngine;

public delegate void OnTakeDamage();

public class PlayerHealth : MonoBehaviour
{
    public static event Action TakeDamage;

    public void OnTakingDamage()
    {
        print("in on taking damage");
        TakeDamage?.Invoke();
    }



    private void OnTriggerEnter(Collider other)
    {
        OnTakingDamage();
    }
}