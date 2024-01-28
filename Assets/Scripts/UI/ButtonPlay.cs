using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    private void OnMouseUpAsButton(){
        Debug.Log("Play Button was pressed!");
        SceneManager.LoadScene("mainLevel+continuousLines");
        Debug.Log("Load Main Game Screen.");
    }
}
