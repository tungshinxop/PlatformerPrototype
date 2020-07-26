using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevels : MonoBehaviour
{
    public VectorValue startingPostion;//Reference to scriptable object script which will alter the player position when changing scene

    public string Level_01;
    public string Level_02;
    public string Level_03;
    public string Level_04;
    public string Level_05;
    public string Level_06;
    public string Level_07;

    public void LoadLevel_1()
    {
        SceneManager.LoadScene(Level_01);
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene(Level_02);
        startingPostion.initialValue = new Vector2(-17.95f, -2.680001f);
    }
    public void LoadLevel_3()
    {
        SceneManager.LoadScene(Level_03);
        startingPostion.initialValue = new Vector2(-53, 1.56f);
    }
    public void LoadLevel_4()
    {
        SceneManager.LoadScene(Level_04);
        startingPostion.initialValue = new Vector2(-16.21f, 6.65f);
    }
    public void LoadLevel_5()
    {
        SceneManager.LoadScene(Level_05);
        startingPostion.initialValue = new Vector2(-30.7f, 5.6f);
    }
    public void LoadLevel_6()
    {
        SceneManager.LoadScene(Level_06);
        startingPostion.initialValue = new Vector2(-54.3f, -5.6f);
    }
    public void LoadLevel_7()
    {
        SceneManager.LoadScene(Level_07);
        startingPostion.initialValue = new Vector2(-53, 1.56f);
    }
}
