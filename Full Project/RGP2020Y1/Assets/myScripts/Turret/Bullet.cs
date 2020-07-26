using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Turret turret;
    private Rigidbody2D rb;
    public float bulletSpeed;
    public int bulletDamage;
    public float timeExist;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.FindGameObjectWithTag("Turret").GetComponent<Turret>();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = turret.shootDir * bulletSpeed;

        StartCoroutine(DestroyTimer());
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>(); //Find the enemy health script of the object collided with

        if (enemyHealth != null)
        {
            enemyHealth.ReceiveDamage(bulletDamage);
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(timeExist);

        Destroy(gameObject);
    }
}
