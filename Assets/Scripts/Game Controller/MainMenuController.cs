using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [SerializeField] private Button _muteButton;
    [SerializeField] private Sprite[] _muteIcons;

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Gameplay");
    }

    private void CheckToPlayMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            _muteButton.image.sprite = _muteIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            _muteButton.image.sprite = _muteIcons[0];
        }
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
        if (GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            _muteButton.image.sprite = _muteIcons[0];
        }
        else if (GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            _muteButton.image.sprite = _muteIcons[1];
        }
    }
}
