using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int health;
    public HealthUIText healthUi;

    // HealthManager is a singleton
    public static HealthManager Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void OnEnable()
    {
        PlayerHealth.TakeDamage += TakeDamage;
    }

    private void OnDisable()
    {
        PlayerHealth.TakeDamage -= TakeDamage;
    }

    void TakeDamage()
    {
        health--;
        healthUi.UpdateText();
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
            print("GAME OVER!");
        }
    }
    
    

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
