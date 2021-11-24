using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; //creates an array from the Sound script
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
        }
    }

    public void PlaySound(string name) //method used for playing sounds
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //finds sound in array based on input name
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!"); //incase name isnt found, returns
            return;
        }
        s.source.Play();
    }
}
