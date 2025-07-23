using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [Header("Mute and Unmute settings")]
    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public Button soundButton;
    [Header("Sound volume settings")]
    public Slider slider;
    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("SoundVolume", 1);
        slider.value= audioSource.volume;
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
    public void MuteAndUnmuteSound()
    {
        if (audioSource.mute)
        {
            audioSource.mute = false;
            soundButton.image.sprite = unmuteSprite;
        }
        else
        {
            audioSource.mute = true;
            soundButton.image.sprite = muteSprite;
        }
    }
    public void ChangeSoundVolume()
    {
        audioSource.volume=slider.value;
        PlayerPrefs.SetFloat("SoundVolume",slider.value);
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
