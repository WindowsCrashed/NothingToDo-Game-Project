using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] List<Sound> sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.voulume;
            s.source.loop = s.loop;
        }    
    }

    public void PlayClip(string name)
    {
        sounds.Find(s => s.name == name).source.Play();
    }

    public void StopClip(string name)
    {
        sounds.Find(s => s.name == name).source.Stop();
    }
}
