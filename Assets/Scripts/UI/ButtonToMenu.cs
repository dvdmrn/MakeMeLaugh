using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonToMenu : MonoBehaviour
{
    private void OnMouseUpAsButton(){
        Debug.Log("Back to main menu button was pressed!");
        SceneManager.LoadScene("UI_TitleScreen");
        Debug.Log("Load Main Menu Screen.");
    }
}
