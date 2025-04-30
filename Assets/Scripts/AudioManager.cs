using UnityEngine.Audio;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class AudioManager : MonoBehaviour
{
    [SerializeField] string[] PlayOnAwake;
    [SerializeField] Sound[] sounds;

    void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = transform.AddComponent<AudioSource>();
            sound.source.name = sound.name;
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
        foreach (string sound in PlayOnAwake)
        {
            Play(sound);
        }
    }
    public void Play(string name)
    {
        Sound targetSound = Array.Find(sounds, sound => sound.name == name);
        targetSound.source.Play();
    }

    public void Stop(string name)
    {
        Sound targetSound = Array.Find(sounds, sound => sound.name == name);
        targetSound.source.Stop();
    }

    public void Pause(string name)
    {
        Sound targetSound = Array.Find(sounds, sound => sound.name == name);
        targetSound.source.Pause();
    }
}
