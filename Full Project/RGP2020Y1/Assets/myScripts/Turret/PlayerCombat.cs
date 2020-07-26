using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;
    public Transform enemyToLock;

    [Header("Knock back")]
    public float thrust;
    public float knockBackTime;

    [Header("Attack range")]
    public Transform attackPoint;
    public float attackRange;
    public LayerMask whatIsEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        //Play attack animation
        anim.SetTrigger("isAttack");
        //Detect enemies in range
        Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, attackRange, whatIsEnemies);

        //Store enemy to target
        if (enemy)
        {
            Debug.Log("We hit " + enemy.name);
            enemyToLock = enemy.transform;



            if (enemy.gameObject.CompareTag("Enemy"))//Check if the enemy hitted is the boss or not, if not, apply knock back effect
            {
                //Knockback 
                //Get the rigidbody of the enemy hitted
                Rigidbody2D enemyRB = enemy.GetComponent<Rigidbody2D>();

                //Turn off is kinematic so that enemy is affected by gravity
                enemyRB.isKinematic = false;

                //Get the knock back direction
                Vector2 knockbackDir = enemy.transform.position - transform.position;
                knockbackDir = knockbackDir.normalized;

                //Add a force to the enemy
                enemyRB.AddForce(knockbackDir * thrust, ForceMode2D.Impulse);
  

                //Set a timer for knockback , if the timer stop, freeze the enemy at that postion
                StartCoroutine(KnockCoroutine(enemyRB));
            }
        }
    }

    private IEnumerator KnockCoroutine(Rigidbody2D enemy)
    {
        //Check if the enemy is dead
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockBackTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
