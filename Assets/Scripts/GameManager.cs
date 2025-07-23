using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool started=false;
    [Header("Pause and Resume settings")]
    public Button pausePlayButton;
    public Text pausePlayText;
    public Sprite pauseSprite;
    public Sprite resumeSprite;
    private void Awake()
    {
        if (instance == null) instance = this;
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
    public void StartGame()
    {
        LevelStarter.instance.StartCounting();
        LevelDistance.instance.StartAddingDis();
        started = true;
        AnimationManager.instance.PlayeAnimation(AnimationManager.AnimationState.Run);
        SoundManager.instance.PlayBgMusic();
    }
    public void PauseAndPlay()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pausePlayText.text = "Pause";
            pausePlayButton.image.sprite = resumeSprite;
            FindAnyObjectByType<AudioSource>().UnPause();
        }
        else
        {
            Time.timeScale = 0;
            pausePlayText.text = "Resume";
            pausePlayButton.image.sprite = pauseSprite;
            FindAnyObjectByType<AudioSource>().Pause();
        }
    }
    public void GameOver()
    {
        //Game over menu show
        int highScore = PlayerPrefs.GetInt("highScore", 0);
        int score = ScoreManager.instance.score;
        if (score > highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        UIManager.instance.GameOverMenu();
        LevelDistance.instance.StopAddingDis();
        AnimationManager.instance.PlayeAnimation(AnimationManager.AnimationState.FallBack);
        SoundManager.instance.StopBgMusic();
        SoundManager.instance.GameOverSound();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
