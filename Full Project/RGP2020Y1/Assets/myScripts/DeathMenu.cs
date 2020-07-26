using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public HealthManager healthManager;

    public void ReloadStartMenu()
    {
        healthManager.currentHealth = healthManager.maxHealth;//Reset the health
        this.gameObject.SetActive(false);
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;//Because die function set Time.timeScale = 0f;
    }


    public void Quit()
    {
        Application.Quit();
    }
}
