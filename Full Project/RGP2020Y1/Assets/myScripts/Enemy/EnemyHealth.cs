using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentEnemyHealth;//The current health of the enemy
    public float maxEnemyHealth;//Max health of enemy

    void Start()
    {
        currentEnemyHealth = maxEnemyHealth;//Set the current health to max health on initialisation
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }

    void Die()
    {
        if(currentEnemyHealth <= 0)
        {
            //Play sound effect

            //Play dead effect

            //Destroy game object
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(int damage)
    {
        Debug.Log("Hurt");
        currentEnemyHealth -= damage;
    }
}
