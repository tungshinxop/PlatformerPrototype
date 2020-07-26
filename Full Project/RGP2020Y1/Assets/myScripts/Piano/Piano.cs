using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piano : MonoBehaviour
{
    bool isOn = false;
    public GameObject door;

    [Header("Piano screen")]
    public GameObject piano;
    public GameObject keyboardEIndicator;

    [Header("Range Modification")] //This is not efficient, could use a script for executing indicator
    public Transform pianoGFXLocation;
    public float radius;
    public LayerMask whatIsPlayer;
    public Animator anim;

    [Header("Piano Code")]
    public string sequenceToOpen;
    public string sequenceInput="";

    private void Update()
    {
        PianoInteraction();
        CompareSequence();
        MemoryFree();
    }

    void PianoInteraction()
    {

        Collider2D playerActivationRange = Physics2D.OverlapCircle(pianoGFXLocation.position, radius, whatIsPlayer);

        if (playerActivationRange)
        {
            //Check if player is in the range of interaction

            //Show outer white line indicate interactable object

            //Show press E instruction
            anim.SetBool("isInRange",true);
            anim.SetBool("isOutsideRange", false);

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isOn)
                {
                    //The piano screen is off, we should:
                    //Turn the piano screen on
                    piano.SetActive(true);

                    //Set is on to true
                    isOn = true;

                }
                else
                {
                    //Turn off the piano screen 
                    piano.SetActive(false);

                    //Reset sequence
                    ResetSequence();

                    //Set is on to false
                    isOn = false;

                }
            }
        }
        else
        {
            //Disable outer white line

            //Disable keyboard instruction
            anim.SetBool("isInRange", false);
            anim.SetBool("isOutsideRange", true);

            //Turn off the piano screen 
            piano.SetActive(false);

            //Reset sequence
            ResetSequence();

            //Set is on to false
            isOn = false;

        }
    }

    void MemoryFree()
    {
        if(sequenceInput.Length > sequenceToOpen.Length)
        {
            ResetSequence();
        }
    }

    void ResetSequence()
    {
        sequenceInput = "";
    }
    void CompareSequence()
    {
        if(sequenceInput == sequenceToOpen)
        {
            //Open sth
            Debug.Log("OPENING DOOR...");
            door.SetActive(false);

            //Turn off the piano screen 
            piano.SetActive(false);
            //Set is on to false
            isOn = false;
        }
    }

    public void AddToSequence(string input)
    {
        sequenceInput += input;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pianoGFXLocation.position, radius);
    }
}
