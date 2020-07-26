using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    static GameObject gameManager;

    void Awake()
    {
        if(gameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            gameManager = this.gameObject;
            DontDestroyOnLoad(gameObject);
        }

        //DontDestroyOnLoad(this.gameObject);
    }
}
