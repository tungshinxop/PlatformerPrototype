using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool isBombInventory;
    public bool wasCratesDestroyed;
    void Start()
    {
        
    }

    public bool StoreBombInventory()
    {
        return isBombInventory = true;
    }
}
