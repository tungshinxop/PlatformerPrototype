using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip clip_1;
    [SerializeField] private AudioClip clip_2;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayClip_1()
    {
        audioSource.clip = clip_1;
        audioSource.Play();
    }

    public void PlayClip_2()
    {
        audioSource.clip = clip_2;
        audioSource.Play();
    }
}
