using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    [SerializeField]
    private TextMeshProUGUI _scoreText, _coinText, _lifeText, _finalScoreText, _finalCoinText;

    [SerializeField] private GameObject _pausePanel, _gameOverPanel;

    [SerializeField] private GameObject _readyButton, _pauseButton;

    private void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        if (_pausePanel.activeInHierarchy)
            _pausePanel.SetActive(false);

        if (_gameOverPanel.activeInHierarchy)
            _gameOverPanel.SetActive(false);

        if (_pauseButton.activeInHierarchy)
            _pauseButton.SetActive(false);

        if (!_readyButton.activeInHierarchy)
            _readyButton.SetActive(true);

        Time.timeScale = 0f;
    }

    private void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        _readyButton.SetActive(false);
        _pauseButton.SetActive(true);

    }

    public void SetScore(int score)
    {
        _scoreText.text = score.ToString();
    }

    public void SetCoinScore(int coinScore)
    {
        _coinText.text = "x" + coinScore.ToString();
    }

    public void SetLifeScore(int lifeScore)
    {
        _lifeText.text = "x" + lifeScore.ToString();
    }

    public void ShowGameOverPanel(int finalScore, int finalCoinScore)
    {
        _gameOverPanel.SetActive(true);
        _pauseButton.SetActive(false);
        _finalScoreText.text = finalScore.ToString();
        _finalCoinText.text = "Coins Collected x" + finalCoinScore.ToString();
        StartCoroutine(LoadMainMenuOnGameOver());
    }

    IEnumerator LoadMainMenuOnGameOver()
    {
        yield return StartCoroutine(AnimationCoroutine.WaitForRealSeconds(3f));
        SceneFader.instance.FadeToLoadScene("MainMenu");
    }

    public void RestartOnPlayerDeath()
    {
        StartCoroutine(PlayerDeathRestart());
    }


    IEnumerator PlayerDeathRestart()
    {
        yield return StartCoroutine(AnimationCoroutine.WaitForRealSeconds(1f));
        SceneFader.instance.FadeToLoadScene("Gameplay");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
        _pauseButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
        _pauseButton.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneFader.instance.FadeToLoadScene("MainMenu");
    }
}
