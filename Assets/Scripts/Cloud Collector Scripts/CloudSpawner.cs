using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _clouds;
    private float _distanceBetweenClouds = 3f;
    private float _minX, _maxX;
    private float _lastCloudPositionY;
    private float _controlX;

    [SerializeField] private GameObject[] _pickups;

    private GameObject _player;

    private void Awake()
    {
        _controlX = 0;
        SetMinAndMaxX();
        CreateClouds();
        _player = GameObject.Find("Player");

        for (int i = 0; i < _pickups.Length; i++)
        {
            _pickups[i].SetActive(false);
        }
    }

    private void Start()
    {
        PositionPlayer();
    }

    void ShuffleClouds(GameObject[] cloudsArray)
    {
        for (int i = 0; i < cloudsArray.Length; i++)
        {
            GameObject temp = cloudsArray[i];
            int random = Random.Range(i, cloudsArray.Length);
            cloudsArray[i] = cloudsArray[random];
            cloudsArray[random] = temp;
        }
    }

    void CreateClouds()
    {
        ShuffleClouds(_clouds);
        float positionY = 0f;

        for (int i = 0; i < _clouds.Length; i++)
        {
            Vector3 temp = _clouds[i].transform.position;
            temp.y = positionY;

            temp.x = GetCloudPosition(temp);

            _lastCloudPositionY = positionY;
            _clouds[i].transform.position = temp;
            positionY -= _distanceBetweenClouds;
        }

    }

    private float GetCloudPosition(Vector3 temp)
    {
        if (_controlX == 0)
        {
            temp.x = Random.Range(0.0f, _maxX);
            _controlX = 1;
        }
        else if (_controlX == 1)
        {
            temp.x = Random.Range(0.0f, _minX);
            _controlX = 2;
        }
        else if (_controlX == 2)
        {
            temp.x = Random.Range(1.0f, _maxX);
            _controlX = 3;
        }
        else if (_controlX == 3)
        {
            temp.x = Random.Range(-1.0f, _minX);
            _controlX = 0;
        }

        return temp.x;
    }
    void SetMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        _maxX = bounds.x - 0.5f;
        _minX = -bounds.x + 0.5f;
    }

    void PositionPlayer()
    {
        GameObject[] killerClouds = GameObject.FindGameObjectsWithTag("KillerCloud");
        GameObject[] safeClouds = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < killerClouds.Length; i++)
        {
            if (killerClouds[i].transform.position.y == 0f)
            {
                Vector3 t = killerClouds[i].transform.position;
                killerClouds[i].transform.position = new Vector3(safeClouds[0].transform.position.x, safeClouds[0].transform.position.y, safeClouds[0].transform.position.z);
                safeClouds[0].transform.position = t;
            }
        }

        Vector3 temp = safeClouds[0].transform.position;

        for (int i = 1; i < safeClouds.Length; i++)
        {
            if (temp.y < safeClouds[i].transform.position.y)
            {
                temp = safeClouds[i].transform.position;
            }
        }

        temp.y += 0.8f;
        _player.transform.position = temp;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cloud" || other.tag == "KillerCloud")
        {
            HandleCloudCollision(other);
        }

    }

    private void HandleCloudCollision(Collider2D other)
    {
        if (other.transform.position.y == _lastCloudPositionY)
        {
            ShuffleClouds(_clouds);
            ShuffleClouds(_pickups);

            Vector3 temp = other.transform.position;

            for (int i = 0; i < _clouds.Length; i++)
            {
                if (!_clouds[i].activeInHierarchy)
                {
                    temp.x = GetCloudPosition(temp);

                    temp.y -= _distanceBetweenClouds;
                    _lastCloudPositionY = temp.y;
                    _clouds[i].transform.position = temp;
                    _clouds[i].SetActive(true);

                    SpawnPickup(i);
                }
            }
        }
    }

    private void SpawnPickup(int i)
    {
        int random = Random.Range(0, _pickups.Length);

        if (_clouds[i].tag != "KillerCloud")
        {
            if (!_pickups[random].activeInHierarchy)
            {
                Vector3 temp2 = _clouds[i].transform.position;
                temp2.y += 0.7f;

                if (_pickups[random].tag == "Life")
                {
                    if (PlayerScore.lifeCount < 2)
                    {
                        _pickups[random].transform.position = temp2;
                        _pickups[random].SetActive(true);
                    }
                }
                else
                {
                    _pickups[random].transform.position = temp2;
                    _pickups[random].SetActive(true);
                }

                _pickups[random].SetActive(true);
            }
        }
    }
}