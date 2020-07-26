using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Inventory inventory;
    
    void Start()
    {
        inventory = GameObject.Find("Game Manager").GetComponent<Inventory>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inventory.StoreBombInventory();
            Destroy(gameObject);
        }
    }
}
