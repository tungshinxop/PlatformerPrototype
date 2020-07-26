using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script in player
//Reference the player to the gamemanager on loading new scene
public class PlayerToGameManager : MonoBehaviour
{
    private HealthManager healthManager;//Reference to player movement script

    void Start()
    {
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();

        healthManager.playerMovementScript = GetComponent<PlayerMovement>();
    }

}
