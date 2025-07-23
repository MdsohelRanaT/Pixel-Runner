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
    public AudioClip countDownClip;
    public AudioClip menuBgClip;
    public AudioClip bgMusic;
    public AudioClip gameOver;
    public AudioClip buttonClick;
    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayMenuBG();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CollectCoinSound()
    {
        audioSource.PlayOneShot(coinSoundClip);
    }
    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(buttonClick);
    }
    public void CountDownSound()
    {
        audioSource.PlayOneShot(countDownClip);
    }
    public void PlayMenuBG()
    {
        audioSource.clip = menuBgClip;
        audioSource.Play();
        audioSource.loop = true;
    }
    public void PlayBgMusic()
    {
        audioSource.clip = bgMusic;
        audioSource.Play();
        audioSource.loop=true;
    }
    public void StopBgMusic()
    {
        audioSource.Stop();
    }
    public void GameOverSound()
    {
        audioSource.PlayOneShot(gameOver);
    }
}
