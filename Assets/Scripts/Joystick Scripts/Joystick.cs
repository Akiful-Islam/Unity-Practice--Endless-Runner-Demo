using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private PlayerMoveJoystick _playerMoveJoystick;

    private void Start()
    {
        _playerMoveJoystick = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left Side")
        {
            _playerMoveJoystick.SetMoveLeft(true);
        }
        else if (gameObject.name == "Right Side")
        {
            _playerMoveJoystick.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _playerMoveJoystick.StopMovement();
    }
}
