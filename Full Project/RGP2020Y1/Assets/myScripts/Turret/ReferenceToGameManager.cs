using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

//This script is in TurretManager
public class ReferenceToGameManager : MonoBehaviour
{
    private TurretHealth turretHealth; //Reference to the script in charge of the turret health in Game Manager

    // Start is called before the first frame update
    void Start()
    {
        turretHealth = GameObject.Find("Game Manager").GetComponent<TurretHealth>();//Get the script mentioned 
        turretHealth.turretManager = GetComponent<TurretManager>();//Set the turret manager in game manager
    }
}
