using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// This script in centipede
/// </summary>
public class CentipdeAttacks : MonoBehaviour
{
    public Transform player;
    [Header("Fire Rocket")]
    public GameObject rocketPref;//Reference to the rocket prefab
    public Transform[] firePoints;//Array references to the fire position
    public float timeBTWRockets;//Timer between each fire
    public float timeBTWRocketsReset;

    [Header("Spit Attack")]
    public GameObject bombPref; //Reference to bomb prefab
    public Transform mouth; //Reference to the transform of mouth gameobject
    public float distance;//Distance of the ray
    private RaycastHit2D hitInfo;//Ray to check if there is player underneath the centipede

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false; //Let's ray ignore centipede collider

        timeBTWRockets = timeBTWRocketsReset;
    }

    // Update is called once per frame
    void Update()
    {
        SpitBomb();
        FireRocket();
    }

    void SpitBomb()
    {
        hitInfo = Physics2D.Raycast(transform.position, Vector2.down, distance);

        if(hitInfo.collider != null)//Check if the raycast hit something
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);

            if (hitInfo.collider.CompareTag("Player"))//Check if the hitted point of raycast is player, if yes do the spit attack
            {
                Debug.Log("Spit!");
                Instantiate(bombPref, mouth.position, Quaternion.identity);//Instantiate a bomb prefab at the mouth of the centipede
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + Vector3.down * distance, Color.green);
        }
    }

    void FireRocket()
    {
        if(timeBTWRockets <= 0)
        {
            for (int i = 0; i < firePoints.Length/2; i++)
            {
                Instantiate(rocketPref, firePoints[i].position, Quaternion.identity);
            }

            timeBTWRockets = timeBTWRocketsReset;
        }
        else
        {
            timeBTWRockets -= Time.deltaTime;
        }
    }
}
