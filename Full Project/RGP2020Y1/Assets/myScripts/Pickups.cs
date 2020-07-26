using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public float rotationSpeed;
    private HealthManager healthManager;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = GameObject.Find("Game Manager").GetComponent<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Spin();
    }

    void Spin()
    {
        transform.Rotate(new Vector3(0, (transform.rotation.y + rotationSpeed)*Time.deltaTime, 0));
    }


    void IsItHealth()
    {
        if(healthManager.currentHealth != healthManager.maxHealth)
        {
            if (this.gameObject.CompareTag("Health"))
            {
                //Debug.Log("Health +1");
                healthManager.currentHealth += 1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(healthManager.currentHealth != healthManager.maxHealth)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                IsItHealth();
                Destroy(gameObject);
            }
        }
    }
}
