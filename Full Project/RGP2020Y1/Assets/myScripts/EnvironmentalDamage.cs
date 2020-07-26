using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalDamage : MonoBehaviour
{
    private HealthManager healthManager;

    private void Start()
    {
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthManager.ReceiveDamage();
        }
    }
}
