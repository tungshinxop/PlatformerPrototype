using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingMissile : MonoBehaviour
{
    private Transform player;//Reference to the player position
    private Rigidbody2D rb;//Reference to the missile rigidbody2D
    public float speed;//Speed of missile
    public float rotateSpeed;//Rotation speed
    private PlaySound playSound;

    private HealthManager healthManager;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();//Get the player's position
        rb = GetComponent<Rigidbody2D>();//Get the missile rigidbody2D
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();//Get the health manager script
        playSound = GameObject.Find("Sound Manager").GetComponent<PlaySound>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }


    void FollowPlayer()
    {
        Vector2 direction = (Vector2)player.position - rb.position;//Get the directon vector between the player and the missile

        direction.Normalize(); //Noramalize vector 

        float rotateAmount = Vector3.Cross(direction, -transform.up).z;//Get the cross product of vector direction between missile and player and the default vector directon of the missile

        rb.angularVelocity = -rotateAmount * rotateSpeed;//Get the perpendicular vector of the cross product and set the rotation of the missile to that vector
        rb.velocity = -transform.up * speed;//Move the missile
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                healthManager.ReceiveDamage();
                playSound.PlayClip_1();
                Destroy(gameObject);
            }
            else if(!collision.gameObject.CompareTag("Missile"))
            {
                playSound.PlayClip_1();
                Destroy(gameObject);
            }
        }
    }
}
