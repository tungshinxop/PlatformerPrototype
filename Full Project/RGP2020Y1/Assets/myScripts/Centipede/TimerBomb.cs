using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script bomb prefab
/// </summary>
public class TimerBomb : MonoBehaviour
{
    public float timer;//Timer count down
    public float timerMax;//Use to set the max timer value and reset the timer
    private SpriteRenderer spriteRenderer;//Reference to the bomb sprite renderer so that we can change it's color
    private HealthManager healthManager;

    [SerializeField] Color[] myColor;

    [Header("Exploding range")]
    public Transform bombPos;//Reference to the bomb transform
    public float damageRadius;//The radius of the custom circle trigger damage
    public LayerMask whatIsPlayer;//
   

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();
        bombPos = transform;//Set bomb position
        timer = timerMax;//Set timer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;//Decrease the value of timer 
        Timer();
    }

    void Timer()
    {
        if(timer <= timerMax/2 && timer >= timerMax/3)//The timer is half the default timer value
        {
            //Flashing orange 
            Debug.Log("Flash orange");
            StartCoroutine(FlashTimerOrange());
        }
        else if(timer<= timerMax/3 && timer >0)//The timer is 1/3 of the default timer value
        {
            //Flashing red
            Debug.Log("Flash red");
            StartCoroutine(FlashTimerRed());

        }
        else if(timer <= 0)
        {
            //Create custom trigger which returns a bool true when detected player
            bool playerInRange = Physics2D.OverlapCircle(bombPos.position, damageRadius, whatIsPlayer);

            //Deal damage to the player if he/she is in the range
            if (playerInRange)
            {
                healthManager.ReceiveDamage();
            }

            //Destroy the bomb
            Destroy(gameObject);

            //Play explode sound and particle effects
        }

    }

    IEnumerator FlashTimerOrange()
    {
        spriteRenderer.color = new Color(1.0f, 0.64f, 0.0f); 
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    IEnumerator FlashTimerRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.white;
    }

    private void OnDrawGizmos()//Draw gizmo
    {
        Gizmos.color = Color.red;//Set gizmo color to red
        Gizmos.DrawWireSphere(bombPos.position, damageRadius);//Draw circle gizmo center:bomb position, radius: damage range
    }
}
