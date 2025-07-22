using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public static LevelDistance instance;
    public int disRun;
    [SerializeField]
    private bool addingDis = false;
    [SerializeField]
    private float disDelay = 0.35f;

    private void Awake()
    {
        if(instance == null) instance = this;
        else Destroy(instance);
    }
    private void Start()
    {
        StartCoroutine("AddingDis");
    }
    void Update()
    {
        
    }

    IEnumerator AddingDis()
    {
        while(true)
        {
            disRun += 1;
            yield return new WaitForSeconds(disDelay);
        }
    }

    public void StopAddingDis()
    {
        StopCoroutine("AddingDis");
    }
}
