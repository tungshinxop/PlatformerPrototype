using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStick : MonoBehaviour
{
    public float speed;
    public GameObject[] wayPoints;

    int nextWayPoint = 1;
    float distanceToPoint;

    private HealthManager healthManager;

    [SerializeField] bool canRotateZ = true;

    // Update is called once per frame
    void Update()
    {
        Move();

        //Get the player's health manager
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();
    }

    void Move()
    {
        //Compare the distance between the enemy and the waypoint
        distanceToPoint = Vector2.Distance(transform.position, wayPoints[nextWayPoint].transform.position);

        //Move the enemy to the waypoint
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[nextWayPoint].transform.position, speed * Time.deltaTime);


        //Check if the enemy reaches the waypoint, if yes rotate 
        if(distanceToPoint < 0.2f)
        {
            Rotate();
        }
    }

    void Rotate()
    {
        //Store current rotation of enemy
        Vector3 currentRotation = transform.eulerAngles;

        if (canRotateZ)
        {
            currentRotation.z += wayPoints[nextWayPoint].transform.eulerAngles.z;
        }
        else
        {
            currentRotation.y = wayPoints[nextWayPoint].transform.eulerAngles.y;
        }

        transform.eulerAngles = currentRotation;

        NextWaitPoint();
    }

    void NextWaitPoint()
    {
        nextWayPoint++;

        if(nextWayPoint == wayPoints.Length)
        {
            nextWayPoint = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthManager.ReceiveDamage();
        }        
    }
}
