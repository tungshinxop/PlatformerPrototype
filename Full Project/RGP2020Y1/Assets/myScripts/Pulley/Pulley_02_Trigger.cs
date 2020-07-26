using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley_02_Trigger : MonoBehaviour
{
    public Pulley pulley;


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Raise platform 1 and lower platform 2
            pulley.Platform_01_Up();
            pulley.Platform_02_Down();
            pulley.isOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            pulley.isOnPlatform = false;
        }
    }
}
