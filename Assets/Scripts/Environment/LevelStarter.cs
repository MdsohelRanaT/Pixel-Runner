using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    public static LevelStarter instance;
    // Start is called before the first frame update
    [SerializeField]
    private GameObject countDown3,countDown2,countDown1,countDownGo,fadeIn;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
    }
    void Start()
    {
        
    }
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1f);
        countDown3.SetActive(true);
        SoundManager.instance.CountDownSound();
        yield return new WaitForSeconds(1f);
        countDown2.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDown1.SetActive(true);
        yield return new WaitForSeconds(1f);
        countDownGo.SetActive(true);
        PlayerMovement.instance.canMove=true;
    }
    public void StartCounting()
    {
        StartCoroutine(CountSequence());
    }
}
