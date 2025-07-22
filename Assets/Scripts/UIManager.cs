using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [Header("Game over panel")]
    public GameObject gameOverPanel;
    public Text score;
    public Text highScore;
    [Header("Score")]
    public Text scoreText;
    public Text distance;
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

    public void UpdateDistanceAndScore()
    {
        scoreText.text = ScoreManager.instance.score.ToString();
        distance.text = LevelDistance.instance.disRun.ToString();
    }
    public void GameOverMenu()
    {
        score.text = "Score: "+ScoreManager.instance.score.ToString();
        highScore.text ="High Score: "+ PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

}
