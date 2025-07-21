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
            CollectTableControl.Instance.coinCount++;
            SoundManager.instance.CollectCoinSound();
        }
        
    }
}
