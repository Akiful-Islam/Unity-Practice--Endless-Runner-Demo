using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector] public int score, coinScore, lifeScore;

    private void Awake()
    {
        MakeSingleton();
    }

    private void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Gameplay")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;
            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);
            }
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            // if (score > PlayerPrefs.GetInt("Highscore"))
            // {
            //     PlayerPrefs.SetInt("Highscore", score);
            // }

            // if (coinScore > PlayerPrefs.GetInt("CoinScore"))
            // {
            //     PlayerPrefs.SetInt("CoinScore", coinScore);
            // }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;
            GameplayController.instance.ShowGameOverPanel(score, coinScore);
        }

        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;

            GameplayController.instance.SetScore(score);
            GameplayController.instance.SetCoinScore(coinScore);
            GameplayController.instance.SetLifeScore(lifeScore);

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GameplayController.instance.RestartOnPlayerDeath();
        }
    }
}

