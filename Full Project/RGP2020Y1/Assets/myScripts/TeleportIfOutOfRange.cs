using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportIfOutOfRange : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float stopDistance;

    public float maxTimerOutOfRange;
    private float timerOutOfRange;

    Collider2D isInRange;
    public Transform dog;
    public float tpRadius;
    public LayerMask whatIsPlayer;
    void Update()
    {
        isInRange = Physics2D.OverlapCircle(dog.position, tpRadius, whatIsPlayer);

        MoveToPlayer();
        TeleportToPlayer();
    }

    void MoveToPlayer()
    {
        if (isInRange)
        {
            if (Vector2.Distance(transform.position, player.transform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = transform.position;
            }
        }
    }

    void TeleportToPlayer()
    {
        if (!isInRange)
        {
            timerOutOfRange += Time.deltaTime;

            if(timerOutOfRange >= maxTimerOutOfRange)
            {
                transform.position = player.transform.position - new Vector3(stopDistance, 0.8f, 0);
                timerOutOfRange = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(dog.position, tpRadius);
    }
}
