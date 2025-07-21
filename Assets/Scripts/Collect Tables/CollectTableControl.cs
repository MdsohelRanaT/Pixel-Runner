using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class CollectTableControl : MonoBehaviour
{
    public static CollectTableControl Instance { get; private set; }
    public int coinCount = 0;
    public Text score;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }
    // Update is called once per frame
    void Update()
    {
        score.text= coinCount.ToString();
    }
}
