using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    public enum AnimationState
    {
        FallBack,Jump,Run,Idle
    }
    public Animator animator;
    private string currentState = "";
    private void Awake()
    {
        if (instance == null)instance = this;
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
    public void PlayeAnimation(AnimationState state)
    {
        string newState = state.ToString();
        animator.ResetTrigger(currentState);
        animator.SetTrigger(newState);
        currentState = newState;
    }
}
