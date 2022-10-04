using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    private GameObject[] _backgrounds;
    private float _lastY;

    private void Start()
    {
        GetBackgroundsAndSetLastY();
    }
    void GetBackgroundsAndSetLastY()
    {
        _backgrounds = GameObject.FindGameObjectsWithTag("Background");
        _lastY = _backgrounds[0].transform.position.y;

        for (int i = 1; i < _backgrounds.Length; i++)
        {
            if (_lastY > _backgrounds[i].transform.position.y)
            {
                _lastY = _backgrounds[i].transform.position.y;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Background")
        {
            if (other.transform.position.y == _lastY)
            {
                Vector3 temp = other.transform.position;
                float height = ((BoxCollider2D)other).size.y;

                for (int i = 0; i < _backgrounds.Length; i++)
                {
                    if (!_backgrounds[i].activeInHierarchy)
                    {
                        temp.y -= height;
                        _lastY = temp.y;

                        _backgrounds[i].transform.position = temp;
                        _backgrounds[i].SetActive(true);
                    }
                }

            }
        }
    }
}
