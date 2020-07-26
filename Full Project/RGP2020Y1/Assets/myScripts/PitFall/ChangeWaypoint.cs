using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWaypoint : MonoBehaviour
{
    public FallDownPit fall;
    void Start()
    {
        fall = GameObject.Find("PitTrigger").GetComponent<FallDownPit>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fall.placeToRespawn = transform;
        }
    }
}
