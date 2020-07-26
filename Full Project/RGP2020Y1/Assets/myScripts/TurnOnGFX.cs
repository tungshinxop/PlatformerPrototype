using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGFX : MonoBehaviour
{
    public GameObject[] whatToActive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        for (int i = 0; i < whatToActive.Length; i++)
        {
            whatToActive[i].SetActive(true);
        }
    }
}
