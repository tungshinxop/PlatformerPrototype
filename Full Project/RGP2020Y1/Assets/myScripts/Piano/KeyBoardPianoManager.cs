using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Placed in the KEYBOARDS
/// </summary>
public class KeyBoardPianoManager : MonoBehaviour
{
    public Piano piano;
    public string keyBoardInput;

    [Header("Audio Source")]
    public AudioSource KeyBoardSound;

    public void Note()
    { 
        KeyBoardSound.Play();
        piano.AddToSequence(keyBoardInput);
    }

}
