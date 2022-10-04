using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _acceleration = 1f;
    [SerializeField] private float _maxSpeed = 16f;

    [HideInInspector] public bool _isMoving;

    private void Start()
    {
        _isMoving = true;
    }
    private void Update()
    {
        if (_isMoving)
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

