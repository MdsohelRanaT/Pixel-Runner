using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    public static StoreManager instance;
    [Header("Characters selection")]
    public Transform characters;
    [SerializeField]
    private Animator animator;
    private void Awake()
    {
        if(instance == null) instance = this;   
        else Destroy(instance);
    }
    // Start is called before the first frame update
    void Start()
    {
        int index = PlayerPrefs.GetInt("CharIndex", 0);
        SelectCharacter(index);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SelectCharacter(int index)
    {
        int temp = 0;
        foreach(Transform character in characters)
        {
            if (temp == index)
            {
                PlayerPrefs.SetInt("CharIndex", index);
                character.gameObject.SetActive(true);
                animator = character.gameObject.GetComponent<Animator>();
                AnimationManager.instance.animator = animator;
            }
            else character.gameObject.SetActive(false);
            temp++;
        }
    }
}
