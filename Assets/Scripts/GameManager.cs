using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool started=false;
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
