using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    
    public CharacterController controller;
    public float moveSpeed = 5f,jumpHeight=3f;
    public float leftRightSpeed = 4f;
    public bool isGrounded=true;
    public bool isRun = false;
    public Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float minX, maxX;
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
            GameManager.instance.GameOver();
        }
    }
}
