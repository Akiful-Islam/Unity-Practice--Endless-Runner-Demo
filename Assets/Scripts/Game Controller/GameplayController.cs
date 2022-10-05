using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private TextMeshProUGUI scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField] GameObject pausePanel, gameOverPanel;

    private void Awake()
    {
        MakeInstance();
    }

    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore.ToString();
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
