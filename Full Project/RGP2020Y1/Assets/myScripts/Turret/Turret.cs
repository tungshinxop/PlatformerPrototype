using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is in Turret prefab
/// </summary>
public class Turret : MonoBehaviour
{
    [Header("Manager")]
    public TurretManager turretManager;//Reference to turret manager

    [Header("Activation Range")]
    public Transform turretPos;//Reference to turret postion
    public float range;//The range for custom trigger
    public LayerMask whatIsPlayer;//Return true the collision between player and turret range

    [Header("Turret shoot")]
    public Transform enemyLock;//Reference to the target locked by player
    public Transform target;//Reference to the target of the turret
    private PlayerCombat playerCombat;//Reference to player's combat script
    public float fireRange;//Fire range of the turret
    public LayerMask whatIsEnemyLocked;//Return true the collision between locked enemy and turret range
    public GameObject bulletPrefab;//Reference to bullet prefab
    private float timeBTWShot;//Timer between each bullet fired
    public float maxTimeBTWShot;//Timer reset
    public Vector2 shootDir;//Shoot direction 

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -5);
        turretManager = GameObject.Find("TurretManager").GetComponent<TurretManager>();//Get the turret manager script
        playerCombat = GameObject.Find("Player").GetComponent<PlayerCombat>();//Get playercombat script
        timeBTWShot = maxTimeBTWShot;//Reset timer on instantiate
    }


    void Update()
    {
        PickUpTurret();
        TurretFire();
    }

    void TurretFire()
    {
        //Store the enemy hiited by player
        if(playerCombat.enemyToLock != null)
        {
            enemyLock = playerCombat.enemyToLock;
        }

       
        if(enemyLock != null)//If the player marked an enemy
        {
            if(Vector2.Distance(transform.position, enemyLock.position) <= fireRange)//Check if the marked enemy is in range, if yes make it the target for the turret
            {
                target = enemyLock;

                if (timeBTWShot <= 0)//Check if the timer between each shot is 0
                {
                    shootDir = target.transform.position - transform.position;//Get the vector direction from the turret and the target
                    shootDir = shootDir.normalized;//Normalize the vector direction
                    Instantiate(bulletPrefab, transform.position, Quaternion.identity);//Instantiate the bullet at turret position
                    timeBTWShot = maxTimeBTWShot;//Reset the timer
                }
                else
                {
                    //Keep the timer working if it is not 0
                    timeBTWShot -= Time.deltaTime;
                }
            }
            else
            {
                target = null; //If the marked enemy is not in the fire range, stop making it the target
            }
        }
    }

    private void PickUpTurret()
    {
        //Custom circle trigger (centre point : turret postion, radius : range) return true the player is in the trigger
        Collider2D playerInRange = Physics2D.OverlapCircle(turretPos.position, range, whatIsPlayer);

        if (playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))//Check if the player pressed E in the trigger
            {
                Debug.Log("Picked up");

                //Clear out the target for the turret
                playerCombat.enemyToLock = null;

                //Store the turret in the inventory
                Destroy(gameObject);
                turretManager.isInInventory = true;
            }
        }
    }

    private void OnDrawGizmos() //Draw gizmo
    {
        Gizmos.color = Color.yellow;//Set gizmo color to yellow
        Gizmos.DrawWireSphere(turretPos.position, range);//Draw cirlce custom trigger gizmo for pick up range
        Gizmos.DrawWireSphere(turretPos.position, fireRange);//Draw cirlce custom trigger gizmo for fire range
    }
}
