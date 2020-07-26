using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulley_01_Trigger : MonoBehaviour
{
    public Pulley pulley;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            //Raise platform 2 and lower platform 1
            pulley.Platform_02_Up();
            pulley.Platform_01_Down();
            pulley.isOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pulley.isOnPlatform = false;
        }
    }
}
