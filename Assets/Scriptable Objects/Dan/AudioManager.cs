using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }
    
    void Start()
    {
        Play("Theme");
    }

    // Play a sound effect/track
    public void Play (string name)
    {
        // throws and error of sound is played that is not of the same name
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
