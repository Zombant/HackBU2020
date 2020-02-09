using UnityEngine.Audio;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    public Sound[] SoundsList;


    void Awake()
    {
        foreach(Sound sound in SoundsList) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.audioClip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public void PlaySound(string name) {
        foreach(Sound sound in SoundsList) {
            if(sound.name == name) {
                sound.source.Play();
                Debug.Log("PLAY");
                break;
            }
        }
        

    }

    public void StopSounds() {
        foreach(Sound sound in SoundsList) {
            sound.source.Stop();
        }


    }

    void Start() {
        switch (Random.Range(0, 3)) {
            case 0:
                PlaySound("music1");
                break;
            case 1:
                PlaySound("music2");
                break;
            case 2:
                PlaySound("music3");
                break;
        }
    }

    void Update() {
        
    }


}
