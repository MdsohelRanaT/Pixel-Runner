using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            ScoreManager.instance.IncreseScore();
            SoundManager.instance.CollectCoinSound();
        }
        
    }
}
