using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    [SerializeField]
    private Text distance;
    [SerializeField]
    private int disRun;
    [SerializeField]
    private bool addingDis = false;
    [SerializeField]
    private float disDelay = 0.35f;
    // Update is called once per frame
    void Update()
    {
        if (!addingDis)
        {
            addingDis = true;
            StartCoroutine(AddingDis());

        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1;
        distance.text = disRun.ToString();
        yield return new WaitForSeconds(disDelay);
        addingDis = false;
    }
}
