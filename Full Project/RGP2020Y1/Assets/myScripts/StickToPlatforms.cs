using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stick player to certain platforms and sometimes give the player controller the features of the platforms :D
/// In Player
/// </summary>
public class StickToPlatforms : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pulley"))//If the player collides with a pulley tagged platform
        {
            //Stick the player to the platform
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pulley"))//If the player stop colliding with the pulley tagged platform
        {
            //Stop sticking the player to the platform
            this.transform.parent = null;
        }
    }
}
