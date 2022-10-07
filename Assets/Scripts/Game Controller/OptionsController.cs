using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{

    [SerializeField] private GameObject _easySign, _mediumSign, _hardSign;
    void Start()
    {
        SetDifficultySign();
    }

    public void SetDifficultySign()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            _easySign.SetActive(true);
            _mediumSign.SetActive(false);
            _hardSign.SetActive(false);
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            _easySign.SetActive(false);
            _mediumSign.SetActive(true);
            _hardSign.SetActive(false);
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            _easySign.SetActive(false);
            _mediumSign.SetActive(false);
            _hardSign.SetActive(true);
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
        SceneFader.instance.FadeToLoadScene("MainMenu");
    }
}
