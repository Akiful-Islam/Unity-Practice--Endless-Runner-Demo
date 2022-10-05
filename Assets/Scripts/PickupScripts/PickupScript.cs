using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DestroyPickup", 5f);
    }

    private void OnDisable()
    {

    }
    void DestroyPickup()
    {
        gameObject.SetActive(false);
    }
}
