using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDownPit : MonoBehaviour
{
    public GameObject left, right;
    private HealthManager healthManager;

    public Transform placeToRespawn;

    void Start()
    {
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touched");
            collision.transform.position = placeToRespawn.position;
            //Destroy(collision.gameObject);
            healthManager.ReceiveDamage();
        }
        else if (collision.gameObject.CompareTag("Turret"))
        {
            Debug.Log("Restart level");
        }
       
    }
}
