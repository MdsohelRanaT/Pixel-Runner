using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColider : MonoBehaviour
{
    private GameObject[] targetObjects;
    [SerializeField]
    private GameObject charAnim;

    private void Update()
    {
        targetObjects = GameObject.FindGameObjectsWithTag("obstacle");
    }

    private void OnTriggerEnter(Collider other)
    {
          
        //foreach (var targetObject in targetObjects)
        //{
        //    if (other.gameObject == targetObject)
        //    {
        //        //gameObject.GetComponent<PlayerMovement>().moveSpeed = 0;
        //        charAnim.GetComponent<Animator>().SetBool("isCollider", true);
        //    }
        //}
    }
}
