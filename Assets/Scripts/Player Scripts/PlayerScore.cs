using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private AudioClip _coinPickupClip, _lifePickupClip;

    private CameraScript _cameraScript;
    private Vector3 _previousPosition;
    private bool _countScore;

    [HideInInspector]
    public static int scoreCount, lifeCount, coinCount;

    private void Awake()
    {
        _cameraScript = Camera.main.GetComponent<CameraScript>();
    }

    private void Start()
    {
        _previousPosition = transform.position;
        _countScore = true;
    }

    private void Update()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (_countScore)
        {
            if (transform.position.y < _previousPosition.y)
            {
                scoreCount++;
                GameplayController.instance.SetScore(scoreCount);
            }
            _previousPosition = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            HandleCoinPickupTrigger();
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Life")
        {
            HandleLifePickupTrigger();
            other.gameObject.SetActive(false);
        }

        if (other.tag == "Bounds" || other.tag == "KillerCloud")
        {
            HandleDeathTrigger();
        }
    }

    private void HandleCoinPickupTrigger()
    {

        coinCount++;
        scoreCount += 200;

        GameplayController.instance.SetScore(scoreCount);
        GameplayController.instance.SetCoinScore(coinCount);

        AudioSource.PlayClipAtPoint(_coinPickupClip, transform.position);
    }

    private void HandleLifePickupTrigger()
    {
        lifeCount++;
        scoreCount += 300;

        GameplayController.instance.SetScore(scoreCount);
        GameplayController.instance.SetLifeScore(lifeCount);

        AudioSource.PlayClipAtPoint(_lifePickupClip, transform.position);
    }

    private void HandleDeathTrigger()
    {
        _cameraScript.isMoving = false;
        _countScore = false;

        lifeCount--;
        transform.position = new Vector3(500, 500, 0);

        GameplayController.instance.ShowGameOverPanel(scoreCount, coinCount);
        GameManager.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);
    }

}
