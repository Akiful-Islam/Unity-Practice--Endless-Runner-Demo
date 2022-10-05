using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    private float minX, maxX;
    void Start()
    {
        SetMinAndMaxX();
    }
    void Update()
    {
        KeepPlayerInBounds();
    }

    private void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        minX = -bounds.x + 0.5f;
        maxX = bounds.x - 0.5f;
    }

    private void KeepPlayerInBounds()
    {
        Vector3 temp = transform.position;
        if (temp.x < minX)
        {
            temp.x = minX;
        }
        else if (temp.x > maxX)
        {
            temp.x = maxX;
        }
        transform.position = temp;
    }
}
