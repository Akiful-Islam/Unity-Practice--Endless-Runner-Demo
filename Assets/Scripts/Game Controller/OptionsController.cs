using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour
{

    [SerializeField] private GameObject easySign, mediumSign, hardSign;
    void Start()
    {
        SetDifficultySign();
    }

    public void SetDifficultySign()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            easySign.SetActive(true);
            mediumSign.SetActive(false);
            hardSign.SetActive(false);
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            easySign.SetActive(false);
            mediumSign.SetActive(true);
            hardSign.SetActive(false);
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            easySign.SetActive(false);
            mediumSign.SetActive(false);
            hardSign.SetActive(true);
        }
    }

    public void SetEasyDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(1);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(0);
        SetDifficultySign();
    }

    public void SetMediumDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(1);
        GamePreferences.SetHardDifficultyState(0);
        SetDifficultySign();
    }

    public void SetHardDifficulty()
    {
        GamePreferences.SetEasyDifficultyState(0);
        GamePreferences.SetMediumDifficultyState(0);
        GamePreferences.SetHardDifficultyState(1);
        SetDifficultySign();
    }



    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
