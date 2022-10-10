using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)] public float voulume;
    [HideInInspector] public AudioSource source;
}
