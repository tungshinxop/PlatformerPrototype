using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuFunctions : MonoBehaviour
{
    public string characterHouse;//Store the string to load the 1st level
    public string chooseLevel;//Store the string to load choose level scene

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene(characterHouse);
    }

    public void LoadChooseLevel()
    {
        SceneManager.LoadScene(chooseLevel);
    }

    //Other
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
