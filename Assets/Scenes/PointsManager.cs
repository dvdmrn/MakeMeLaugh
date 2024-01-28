using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public int points;
    public PointsUIText pointsUi;

    // PointsManager is a singleton
    public static PointsManager Instance { get; private set; }
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
        PlayerHealth.TakeSmiles += TakeSmiles;
    }

    private void OnDisable()
    {
        PlayerHealth.TakeSmiles -= TakeSmiles;
    }

    void TakeSmiles()
    {
        points += 5;
        Debug.Log("SMILE OR FROWN FIRED!");
        pointsUi.UpdateText();
    }
}
