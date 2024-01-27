using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting.");
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Debug.Log("Load next scene by index.");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Load Menu.");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Conor_FaceDetector");
        Debug.Log("Load Main Game Screen.");
    }
    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
        Debug.Log("Load Credits page.");
    }
    public void LoadHelp()
    {
        SceneManager.LoadScene("Help");
        Debug.Log("Load Help page.");
    }
    public void LoadCongratulations()
    {
        SceneManager.LoadScene("Congratulations");
        Debug.Log("Load Congratulations page.");
    }

}
