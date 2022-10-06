using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI highScoreText, coinText;

    private void Start()
    {
        SetScoreBasedOnDifficulty();
    }

    public void SetScore(int score, int coins)
    {
        highScoreText.text = score.ToString();
        coinText.text = coins.ToString() + "x Coins Collected";
    }

    public void SetScoreBasedOnDifficulty()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetMediumDifficultyHighScore(), GamePreferences.GetMediumDifficultyCoinScore());
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetHardDifficultyHighScore(), GamePreferences.GetHardDifficultyCoinScore());
        }
    }

    public void BackToMainMenu()
    {
        SceneFaderScript.instance.FadeToLoadScene("MainMenu");
    }
}
