using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

/// <summary>
/// In every enemies who have patrol behaviour
/// </summary>
public class Enemy : MonoBehaviour
{
    public Animator anim;
    private float currentSpeed;
    private HealthManager healthManager;


    RaycastHit2D hitInfo;

    //Variable for smoothdamp
    float smoothVelocity; 
    public float smoothTime;

    [Header("Reuseable")]
    public float turnHeadDistance;
    public float visionDistance;
    private Vector2 headDir;
    public LayerMask whatIsPlayer;
    public float chargeSpeed;
    //public float hitBoxRange;

    [Header("Patrol")]
    public float patrolSpeed; //Patrol spped
    public Transform head;  //The position from which ray will be cast from wether to dectect collision of player
    public bool isMovingLeft = true;
    //public bool isMovingRight = true;
    public LayerMask whatIsObstacle;

    //Timer for idle time
    public float stopTimeRemember; //Timer variable to tweak in script
    public float stopTime;//Timer set in inspector to set how long to wait before flip

    void Start()
    {
        //Direction  
        headDir = -transform.right;

        stopTimeRemember = stopTime;

        //Set default state to walk
        currentSpeed = patrolSpeed;

        //Get the player's health manager
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();

    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
        SpotPlayer();
        //AttackPlayer();
    }

    //void AttackPlayer()
    //{
    //    //A bool check if player is in range
    //    bool playerInHitBox = Physics2D.OverlapCircle(head.position, hitBoxRange, whatIsPlayer);

    //    if (playerInHitBox)
    //    {
    //        //Debug.Log("Attack");
    //    }
    //}

    void SpotPlayer()
    {

        hitInfo = Physics2D.Raycast(head.position, -transform.right, visionDistance, whatIsPlayer);
       
        //This return true when player in range of the ray
        if (hitInfo)
        {
            ChargeTowardPlayer();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthManager.ReceiveDamage();
        }
    }

    void ChargeTowardPlayer()
    {
        float targetSpeed;
        Debug.Log("Detected player! Now charge toward");
        //Change the enemy speed
        targetSpeed = chargeSpeed;

        //Damp the movement for smoother transition
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref smoothVelocity, smoothTime);

        //Change animation to running
        anim.SetBool("isRunning", true);

        //Destroy the timer for stop/idle so that the enemy would always charge
        stopTimeRemember = 0;
        stopTime = 0;

        //Change all the speed value to the charge speed
        patrolSpeed = chargeSpeed;
    }

    void Patrol()
    {
        //Move the enemy to the left
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        RaycastHit2D obstacleInfo = Physics2D.Raycast(head.position, headDir, turnHeadDistance, whatIsObstacle);

        if (obstacleInfo)
        {
            if (isMovingLeft)
            {
                if(stopTimeRemember <= 0)
                {
                    //Make the enemy move again
                    currentSpeed = patrolSpeed;
                    //Play walk animation
                    anim.SetBool("isIdle", false);

                    //Flip the enemy if it is moving to the left and meet and obstacle
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    isMovingLeft = false;
                    
                    //Reset the timer when it reaches 0
                    stopTimeRemember = stopTime;
                }
                else
                {
                    //Stop the enemy
                    currentSpeed = 0;
                    //Play idle animation
                    anim.SetBool("isIdle",true);

                    //Start the timer 
                    stopTimeRemember -= Time.deltaTime;
                }
            }
            else
            {
                if (stopTimeRemember <= 0)
                {
                    //Make the enemy move again
                    currentSpeed = patrolSpeed;
                    //Play walk animation
                    anim.SetBool("isIdle", false);

                    //Flip the enemy if it is moving to the right and meet and obstacle
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    isMovingLeft = true;
                    stopTimeRemember = stopTime;
                }
                else
                {
                    //Stop the enemy
                    currentSpeed = 0;
                    //Play idle animation
                    anim.SetBool("isIdle", true);

                    stopTimeRemember -= Time.deltaTime;
                }
            }      
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawWireSphere(head.position, hitBoxRange);
    //}
}
