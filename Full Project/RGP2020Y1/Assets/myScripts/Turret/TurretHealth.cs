using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scipt in Game manager
/// </summary>
public class TurretHealth : MonoBehaviour
{
    public float maxHealth;//Reference to the max health of the turret
    public float currentHealth;//Reference to the current health of turret

    public bool isDestroyed = false;//Check the current state of the turret

    public float collectedTurretHealth = 0;//Reference to the number of health pickups for the turret
    public float healthNeededToRevive;//Get the the health pickups needed to revive the turret

    public TurretManager turretManager;//Reference to the TurretManger script

    void Start()
    {
        currentHealth = maxHealth;//Set the current health to default max health when the game start
        turretManager = GameObject.Find("TurretManager").GetComponent<TurretManager>();//Get the the actual turret manager script at the start of the game
    }

    // Update is called once per frame
    void Update()
    {
        TurretDestroy();
        ChangesInHealth();
    }

    public void TurretDestroy()//Check if the current health of the turret is 0
    {
        if(currentHealth <= 0)
        {
            Debug.Log("Turret Destroy");
            isDestroyed = true; //Set this bool to true so that the game manager know that the turret is destroyed
            Destroy(GameObject.Find("Turret"));//Destroy the turret
            turretManager.isInInventory = false; //This stop player from spawning turret when it is destroyed
        }
    }

    public void ChangesInHealth()
    {
        if (isDestroyed)
        {
            if(collectedTurretHealth >= healthNeededToRevive)//Check if players have collected enough to revive the turret
            {
                turretManager.isInInventory = true;//Enable the player to spawn the turret
                collectedTurretHealth = 0;//Reset the inventory for health
            }
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            collectedTurretHealth += 1;//Store one health pickup
        }
    }
}
