using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    private float distanceBetweenClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;

    [SerializeField] private GameObject[] pickups;

    private GameObject player;

    private void Awake()
    {
        controlX = 0;
        setMinAndMaxX();
        CreateClouds();


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
        ShuffleClouds(clouds);
        float positionY = 0f;

        for (int i = 0; i < clouds.Length; i++)
        {
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionY;

            if (controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1;
            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2;
            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3;
            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0;
            }

            lastCloudPositionY = positionY;
            clouds[i].transform.position = temp;
            positionY -= distanceBetweenClouds;
        }

    }
    void setMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;
    }
}