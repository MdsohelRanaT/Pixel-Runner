using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    
    public CharacterController controller;
    public float moveSpeed = 5f,jumpHeight=3f;
    public float leftRightSpeed = 4f;
    public bool isGrounded=true;
    public bool isRun = true;
    public bool canMove = false;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float minX, maxX;
    public float smoothFactor = 10f;
    [Header("Android Controller")]
    public Vector3 startPos,endPos;
    public float minSwipeDis = 1f;
    public float maxTime = 2f;
    public float startTime, endTime;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(instance);
    }
    private void Start()
    {
        controller=GetComponent<CharacterController>();
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance,groundMask);
        if (isRun) 
        {
            UIManager.instance.UpdateDistanceAndScore();
            Movement();
        }
            
            
        ApplyGravity();
    }
    
    void Movement()
    {
        controller.Move(transform.forward * moveSpeed * Time.deltaTime);
        if(canMove)
        {
#if UNITY_ANDROID
        HandleAndroidInput();
#else
            HandleAnotherInput();
#endif
        }


    }
    void HandleAndroidInput()
    {
        float x = Input.acceleration.x;
        controller.Move(transform.right * x * leftRightSpeed*2 * Time.deltaTime);
        Vector3 currentPos = transform.position;
        currentPos.x = Mathf.Clamp(currentPos.x, minX, maxX);
        Vector3 move = currentPos-transform.position;
        controller.Move(move);

        AndroidJumpInput();
        
    }
    void HandleAnotherInput()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (gameObject.transform.position.x > minX)
            {
                controller.Move(transform.right * (-leftRightSpeed) * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < maxX)
            {
                controller.Move(transform.right * leftRightSpeed * Time.deltaTime);
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void AndroidJumpInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                startPos = touch.position;
                startTime = Time.time;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;
                Vector3 distance = endPos - startPos;
                float swipeDist = distance.magnitude;
                float swipeTime = endTime - startTime;
                bool isJump = distance.y > distance.x;
                if (swipeDist >= minSwipeDis && swipeTime < maxTime && isJump) Jump();
            }

            

        }
    }
    void Jump()
    {
        velocity.y = Mathf.Sqrt(-2f*gravity*jumpHeight);
        AnimationManager.instance.PlayeAnimation(AnimationManager.AnimationState.Jump); 
    }
    void ApplyGravity()
    {
        velocity.y += gravity*Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
        if(velocity.y <0 && isGrounded)
        {
            velocity.y = -2f;
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            isRun = false;
            canMove = false;
            GameManager.instance.GameOver();
        }
    }
}
