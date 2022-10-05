using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{
    void Start()
    {

    }

    public void SetDifficultyEasy()
    {
        //TODO: Implement Set Difficulty Easy
    }

    public void SetDifficultyMedium()
    {
        //TODO: Implement Set Difficulty Medium
    }

    public void SetDifficultyHard()
    {
        //TODO: Implement Set Difficulty Hard
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
