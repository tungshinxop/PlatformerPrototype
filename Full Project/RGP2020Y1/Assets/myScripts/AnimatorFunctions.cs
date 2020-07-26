using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will play particle effects and sounds
public class AnimatorFunctions : MonoBehaviour
{
    [Header("Particle System")]
    [SerializeField] private ParticleSystem particle1;
    [SerializeField] private ParticleSystem particle2;
    [SerializeField] private ParticleSystem particle3;
    [SerializeField] private ParticleSystem particle4;
    [SerializeField] private ParticleSystem particle5;
    [SerializeField] private ParticleSystem particle6;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayParticle_1()
    {
        particle1.Play();
    }
    public void PlayParticle_2()
    {
        particle2.Play();
    }

    public void PlayParticle_3()
    {
        particle3.Play();
    }

    public void PlayParticle_4()
    {
        particle4.Play();
    }

    public void PlayParticle_5()
    {
        particle5.Play();
    }

    public void PlayParticle_6()
    {
        particle6.Play();
    }

    public void PlaySound_1()
    {
        audioSource.clip = audioClip1;
        audioSource.Play();
    }
}
