using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectSource;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip hit;
    [SerializeField] private AudioClip restart;

    private void Awake()
    {
        Instance = this;
    }

    public void Play(AudioType type)
    {
        switch (type)
        {
            case AudioType.Music:
                musicSource.clip = music;
                musicSource.Play();
                break;
            case AudioType.Hit:
                effectSource.clip = hit;
                effectSource.Play();
                break;
            case AudioType.Restart:
                effectSource.clip = restart;
                effectSource.Play();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }   
    }
}

public enum AudioType
{
    Music,
    Hit,
    Restart
}