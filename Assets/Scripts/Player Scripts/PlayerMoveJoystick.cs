using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    public float speed = 5f;
    public float maxVelocity = 5f;

    private Rigidbody2D _myBody;
    private Animator _animator;

    private bool _moveLeft, _moveRight;
    private void Awake()
    {
        _myBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_moveLeft)
        {
            MoveLeft();
        }
        if (_moveRight)
        {
            MoveRight();
        }
    }

    public void SetMoveLeft(bool moveLeft)
    {
        _moveLeft = moveLeft;
        _moveRight = !moveLeft;
    }

    public void StopMovement()
    {
        _moveLeft = _moveRight = false;
        _animator.SetBool("isWalking", false);
    }
    private void MoveLeft()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(_myBody.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = -speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = -1.3f;
        transform.localScale = temp;


        _animator.SetBool("isWalking", true);

        _myBody.AddForce(new Vector2(forceX, 0));
    }
    private void MoveRight()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(_myBody.velocity.x);

        if (vel < maxVelocity)
        {
            forceX = speed;
        }

        Vector3 temp = transform.localScale;
        temp.x = 1.3f;
        transform.localScale = temp;

        _animator.SetBool("isWalking", true);

        _myBody.AddForce(new Vector2(forceX, 0));
    }


}
