using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

[System.Serializable]
public class Sound
{
    public string soundName;

    public AudioClip clip;

    public AudioSource audioSource;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
        }
    }

    public void OnUIButtonClick(string name)
    {
        Sound sound = Array.Find(sounds, sound => sound.soundName == name);
        sound.audioSource.Play();
    }
}
