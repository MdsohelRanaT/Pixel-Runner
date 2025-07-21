using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [Header("Audio source")]
    public AudioSource audioSource;
    [Header("Audio Clip")]
    public AudioClip coinSoundClip;
    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CollectCoinSound()
    {
        audioSource.PlayOneShot(coinSoundClip);
    }
}
