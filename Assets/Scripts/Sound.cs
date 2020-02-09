using UnityEngine.Audio;
using System.Collections.Generic;
using System;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public AudioClip audioClip;

    public float volume;

    public float pitch;

    public string name;

    [HideInInspector]
    public AudioSource source;

    public bool loop;

    public bool isMusic;

}
