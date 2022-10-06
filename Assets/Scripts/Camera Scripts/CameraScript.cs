using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _acceleration = 1f;
    private float _maxSpeed = 16f;

    [SerializeField] private float _easyDifficultySpeed = 5f;
    [SerializeField] private float _mediumDifficultySpeed = 8f;
    [SerializeField] private float _hardDifficultySpeed = 12f;

    [HideInInspector] public bool isMoving;

    private void Start()
    {
        SetDifficultyCameraSpeed();

        isMoving = true;
    }

    private void SetDifficultyCameraSpeed()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            _maxSpeed = _easyDifficultySpeed;
        }

        if (GamePreferences.GetMediumDifficultyState() == 1)
        {
            _maxSpeed = _mediumDifficultySpeed;
        }

        if (GamePreferences.GetHardDifficultyState() == 1)
        {
            _maxSpeed = _hardDifficultySpeed;
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveCamera();
        }
    }

    private void MoveCamera()
    {
        Vector3 temp = transform.position;
        float oldY = temp.y;
        float newY = temp.y - _speed * Time.deltaTime;

        temp.y = Mathf.Clamp(temp.y, oldY, newY);
        transform.position = temp;

        _speed += _acceleration * Time.deltaTime;

        if (_speed >= _maxSpeed)
        {
            _speed = _maxSpeed;
        }
    }
}

