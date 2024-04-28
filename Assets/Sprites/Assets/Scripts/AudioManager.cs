using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------ Audio Source ---------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("------------ Audio Clip ---------------")]
    public AudioClip background;
    public AudioClip click;

    private void Start ()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
