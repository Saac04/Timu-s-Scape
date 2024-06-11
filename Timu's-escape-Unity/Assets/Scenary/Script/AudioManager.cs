using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource MusicSource;


    public AudioClip MusicClip;


    public void Start()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }
}
