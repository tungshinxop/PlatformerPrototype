using System.Net.Mail;
using UnityEngine;


//This script in game manager
public class HealthManager : MonoBehaviour
{
    public float maxHealth;//Reference to players' current health
    public float currentHealth;//Get the max players' heatlth
    public GameObject deathScreen;
    public PlayerMovement playerMovementScript;//Reference to player movement script
    void Start()
    {
        currentHealth = maxHealth;//Set the health of the player when the game start
        playerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovementScript == null)
        {
            Debug.Log("Failed to load script");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReceiveDamage();
        }


        //Check if the player health is <= 0, if yes call the die function
        if(currentHealth <= 0)
        {
            Die();
        }
    }


    void Die()
    {
        //Play death sound

        //Pause the game
        Time.timeScale = 0f;

        //Turn on death screen
        deathScreen.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += 1;
            }
            else
            {
                return;
            }
        }
    }

    public void AddHealth()
    {
        currentHealth += 1;
    }

    public void ReceiveDamage()
    {
        if(playerMovementScript.isHurt == false)
        {
            currentHealth -= 1;
            Debug.Log("Health -1");
            StartCoroutine(playerMovementScript.Flash());
        }
    }
}
