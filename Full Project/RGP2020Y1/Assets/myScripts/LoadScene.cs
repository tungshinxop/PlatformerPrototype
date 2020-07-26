using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;//Name of the string to load
    
    public void Load()
    {
        SceneManager.LoadScene(sceneToLoad);//Load the scene according to the string 
    }
}
