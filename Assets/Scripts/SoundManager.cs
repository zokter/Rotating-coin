using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour 
{
    [SerializeField] private List<AudioClip> clips;
    private GameObject soundGameObject;
    private AudioSource audioSource;

    public void PlaySound()
    {
        if(soundGameObject == null)
        {
            soundGameObject = new GameObject("Sound");
            audioSource = soundGameObject.AddComponent<AudioSource>();
        }
        audioSource.PlayOneShot(clips[(int)Random.Range(0, clips.Count)]);
    }
}
