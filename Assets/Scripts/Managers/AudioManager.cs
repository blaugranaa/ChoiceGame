using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip dieSound;

    AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        EventManager.OnCharacterDie.AddListener(PlayDieSound);
    }
    public void PlayDieSound()
    {
        //audioSource.clip = dieSound;
        audioSource.PlayOneShot(dieSound);
    }
}
