using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
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

    }

}
