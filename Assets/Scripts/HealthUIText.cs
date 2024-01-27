using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUIText : MonoBehaviour
{
    private TextMeshProUGUI _tmp;
    

    // Start is called before the first frame update
    void Start()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }

    public void UpdateText()
    {
        _tmp.text = $"HP: {HealthManager.Instance.health}";
    }

    
}
