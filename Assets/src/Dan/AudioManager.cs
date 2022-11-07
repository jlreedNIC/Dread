using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


// public enum SFXTYPE
// {
//     step = 0,
//     health;
// }



public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource as_sfx;
    private AudioSource[] as_music;

    [SerializeField] private SFXGroup[] sfxGroups;

    [System.Serializable]
    private class SFXGroup
    {
        [SerializeField] private string name;
        public AudioClip[] sounds;
        public float[] volumes;
    }


    void Awake()
    {
        instance = this;
        as_sfx = transform.Find("AS_SFX").GetComponent<AudioSource>();
        as_music = new AudioSource[2];

        for(int i = 0; i < as_music.Length; i++)
        {
            as_music[i] = transform.Find("AS_MUSIC_" + i.ToString()).GetComponent<AudioSource>();
        }
    }
}
