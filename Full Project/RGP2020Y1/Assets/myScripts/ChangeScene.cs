using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script is in every door trigger
/// </summary>
public class ChangeScene : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;


    public Transform doorPos;//Reference to the door 'trigger' postion
    public float width, height;//The value to create custom box trigger
    public LayerMask whatIsPlayer;//The layermask refer to player to return 'bool' true

    public GameObject textToActive;

    public string sceneToLoad;//The string to load
    public Vector2 playerPos;//Player position in the loaded scene
    public VectorValue positionInMemory;//Reference to the VectorValue script

    private void Start()
    {
        doorPos = this.transform;//Set doorPos to the position of the door trigger
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //A bool return true if a game object tagged player is in range of a custom box trigger with the position of doorPos nad width,height as width and height
        bool playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height),0,whatIsPlayer);

        if (playerDetected == true)
        {
            textToActive.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))//Check if player press E in the custom box trigger
            {
                positionInMemory.initialValue = playerPos;//Store the postion at which player pressed E 
                PlayDoorSound();
                SceneManager.LoadScene(sceneToLoad);//Load the scene accordingly
            }
        }
        else
        {
            textToActive.SetActive(false);
        }
    }

    void PlayDoorSound()
    {
        if(soundClip != null)//This is for resusing script when I dont want to play sound
        {
            audioSource.clip = soundClip;
            audioSource.Play();
        }
    }



    private void OnDrawGizmos() //Draw gizmo
    {
        Gizmos.color = Color.blue; //Set gizmo color to blue
        Gizmos.DrawWireCube(doorPos.position, new Vector2(width, height)); //Draw box gizmo at doorPos postion with the width and height as stated
    }
}
