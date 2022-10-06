using System;
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

    private void Start()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {
            GamePreferences.SetEasyDifficultyState(1);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);

            GamePreferences.SetMediumDifficultyState(0);
            GamePreferences.SetMediumDifficultyCoinScore(0);
            GamePreferences.SetMediumDifficultyHighScore(0);

            GamePreferences.SetHardDifficultyState(0);
            GamePreferences.SetHardDifficultyCoinScore(0);
            GamePreferences.SetHardDifficultyHighScore(0);

            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 0);
        }
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += LevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= LevelFinishedLoading;
    }

    void LevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Gameplay")
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
            HandleGameOver(score, coinScore);
        }

        else
        {
            HandleRetryGame(score, coinScore, lifeScore);
        }
    }

    private void HandleGameOver(int score, int coinScore)
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetNewEasyDifficultyHighScore(score, coinScore);
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            SetNewMediumDifficultyHighScore(score, coinScore);
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            SetNewHardDifficultyHighScore(score, coinScore);
        }

        gameStartedFromMainMenu = false;
        gameRestartedAfterPlayerDied = false;
        GameplayController.instance.ShowGameOverPanel(score, coinScore);
    }

    private void HandleRetryGame(int score, int coinScore, int lifeScore)
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

    private void SetNewEasyDifficultyHighScore(int score, int coinScore)
    {
        int highScore = GamePreferences.GetEasyDifficultyHighScore();
        int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

        if (highScore < score)
        {
            GamePreferences.SetEasyDifficultyHighScore(score);
        }

        if (coinHighScore < coinScore)
        {
            GamePreferences.SetEasyDifficultyCoinScore(coinScore);
        }
    }

    private void SetNewMediumDifficultyHighScore(int score, int coinScore)
    {
        int highScore = GamePreferences.GetMediumDifficultyHighScore();
        int coinHighScore = GamePreferences.GetMediumDifficultyCoinScore();

        if (highScore < score)
        {
            GamePreferences.SetMediumDifficultyHighScore(score);
        }

        if (coinHighScore < coinScore)
        {
            GamePreferences.SetMediumDifficultyCoinScore(coinScore);
        }
    }

    private void SetNewHardDifficultyHighScore(int score, int coinScore)
    {
        int highScore = GamePreferences.GetHardDifficultyHighScore();
        int coinHighScore = GamePreferences.GetHardDifficultyCoinScore();

        if (highScore < score)
        {
            GamePreferences.SetHardDifficultyHighScore(score);
        }

        if (coinHighScore < coinScore)
        {
            GamePreferences.SetHardDifficultyCoinScore(coinScore);
        }
    }
}

