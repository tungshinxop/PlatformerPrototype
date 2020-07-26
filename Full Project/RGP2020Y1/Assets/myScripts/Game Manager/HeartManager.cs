using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public int heartContainersValue;
    public HealthManager playerCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = GameObject.Find("Game Manager").GetComponent<HealthManager>();
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i =0; i< heartContainersValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.currentHealth;

        for (int i = 0; i < heartContainersValue; i++)
        {
            if(i<= tempHealth-1)
            {
                //Full heart
                hearts[i].sprite = fullHeart;

            }else if (i >= tempHealth)
            {
                //Empty heart
                hearts[i].sprite = emptyHeart;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        UpdateHearts();
    }
}
