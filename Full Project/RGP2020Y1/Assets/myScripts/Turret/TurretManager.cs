using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    [Header("Turret values")]
    public bool isInInventory;//Check if player has picked up the turret
    public float damage;//Damage value
    public float range;//Range value
    public bool canBeAttacked = true;//Check if the turret can be attack or not

    [Header("Spawn turret components")]
    public GameObject turret;//Reference to the turret prefab
    private Transform playerPos;//Reference to the player postion

    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();//Get player position
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTurretIfPickedUp();
    }

    void SpawnTurretIfPickedUp()
    {
        //Spawn the turret if the player press the right button and the turret is in inventory
        if (isInInventory)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                Vector3 spawnPos = new Vector3(playerPos.position.x, playerPos.position.y, -5);

                Instantiate(turret, spawnPos, Quaternion.identity);

                //State that the turret is spawned
                isInInventory = false;
            }
        }
    }
}
