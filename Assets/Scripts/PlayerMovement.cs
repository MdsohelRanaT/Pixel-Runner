using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f,jumpForce=5f;
    public float leftRightSpeed = 4f;
    public static bool canMove =false;
    private bool isGround;
    private Rigidbody rb;
    // Update is called once per frame
    private void Start()
    {
        rb= GetComponent<Rigidbody>();
    }
    void Update()
    {
        transform.Translate(Vector3.forward *moveSpeed*Time.deltaTime,Space.World);
        if(canMove)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
                }
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow) && isGround)
            {
                rb.useGravity = true;
                rb.AddForce(Vector3.up*jumpForce*Time.deltaTime);
                isGround = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            rb.useGravity = false;
        }
    }
}
