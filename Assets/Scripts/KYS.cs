using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYS : MonoBehaviour
{
    public float timeOut;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroySelf), timeOut);    
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }

}
