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
        CountScore();
    }

    private void CountScore()
    {
        if (_countScore)
        {
            if (transform.position.y < _previousPosition.y)
            {
                scoreCount++;
            }
            _previousPosition = transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Coin")
        {
            coinCount++;
            AudioSource.PlayClipAtPoint(_coinPickupClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Life")
        {
            lifeCount++;
            AudioSource.PlayClipAtPoint(_lifePickupClip, transform.position);
            target.gameObject.SetActive(false);
        }

        if (target.tag == "Bounds" || target.tag == "KillerCloud")
        {
            _cameraScript.isMoving = false;
            _countScore = false;

            lifeCount--;
            transform.position = new Vector3(500, 500, 0);
        }
    }
}
