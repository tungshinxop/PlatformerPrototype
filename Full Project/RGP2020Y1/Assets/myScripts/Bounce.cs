using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///This script is in every game object that can add upward force to the player
/// </summary>
public class Bounce : MonoBehaviour
{
    private AudioSource audioSource;//Reference to the audio source
    public AudioClip soundClip;
    public Animator anim;//Reference to player's animator
    public PlayerMovement playerMovement;//Reference to PlayerMovement script
    public float bounceAmount;//The upward force add to player when he/she first collides with the game object
    public float maxBounceAmount;//Set the limit for bounce amount
    private float startBounceAmount;//The upward force add to player when he/she first collides with the game object
    private Rigidbody2D rbPlayer;//Reference to player's rigidbody2D
    private PlayerMovement playerFeet;//Reference to player's feet to check if he/she is grounded

    void Start()
    {
        rbPlayer = GameObject.Find("Player").GetComponent<Rigidbody2D>();//Get the player rigidbody2D
        playerFeet = GameObject.Find("Player").GetComponent<PlayerMovement>();//Get the player's movement script
        startBounceAmount = bounceAmount;//Set start bounce amount to the bounce amount
        audioSource = GetComponent<AudioSource>();//Get the audio source of the holder of the script
    }

    private void PlaySound()
    {
        if(soundClip != null)//Reuseable when I dont want to play sound
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }


    private void Update()
    {
        //Check if the player touch the ground
        //if yes reset the bounce amount
        if (playerFeet.feetToGround)
        {
            bounceAmount = startBounceAmount;
        }

        //Execute Jump,Fall,Land animation accordingly to the player's movement script
        playerMovement.JumpStateMachine();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            anim.SetBool("isJumping", true);//Play jump animation when player touch the bounce object

            PlaySound();//Play sound effect if available

            //Add a upward force when player jump on a bounce ball
            rbPlayer.AddForce(Vector2.up * bounceAmount);


            if(bounceAmount < maxBounceAmount)//Increase bounce amount if it hasn't reached the limited bounce amount
            {
                bounceAmount += 30;
            }
            else
            {
                bounceAmount = maxBounceAmount;
            }
            //Debug.Log("Bounce Amount" + bounceAmount);        
        }        
    }
}
