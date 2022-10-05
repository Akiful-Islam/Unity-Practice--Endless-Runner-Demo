using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    void Start()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ShowOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void ShowHighScore()
    {
        SceneManager.LoadScene("HighScore");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToggleMute()
    {
        //TODO: Implement Toggle Mute
    }
}
