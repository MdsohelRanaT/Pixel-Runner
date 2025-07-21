using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 50;
    public bool isCreatingSection = false;
    public int secNum;

    // Update is called once per frame
    void Update()
    {
        if (!isCreatingSection)
        {
            isCreatingSection = true;
            StartCoroutine(CreateSection());
        }
    }
    IEnumerator CreateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(7);
        isCreatingSection = false;
    }
}
