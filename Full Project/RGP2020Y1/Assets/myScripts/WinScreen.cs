using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;
    public EnemyHealth centipedeHealth;


    // Update is called once per frame
    void Update()
    {
        if(centipedeHealth.currentEnemyHealth <=0)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
