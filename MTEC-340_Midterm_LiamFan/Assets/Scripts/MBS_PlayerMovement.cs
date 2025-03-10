using System;
using UnityEngine;

public class MBS_PlayerMovement : MonoBehaviour
{
    //movement scale
    public float PlayerSpeed = 5.0f;
    public float JumpForce = 5.0f;
    
    //keyboard inputs
    public KeyCode MoveLeft;
    public KeyCode MoveRight;
    public KeyCode Jump;
    
    //jump
    private Rigidbody2D rbPlayer;
    private bool onGround;
    
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        float movementX = 0.0f;
        
        //left and right movement
        if (Input.GetKey(MoveLeft))
        {
            movementX -= PlayerSpeed;
        }
        
        if (Input.GetKey(MoveRight))
        {
            movementX += PlayerSpeed;
        }
        transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime;
        
        //jumping

        if (Input.GetKey(Jump) && onGround == true)
        {
            rbPlayer.linearVelocity = new Vector2(rbPlayer.linearVelocity.x, JumpForce);
            onGround = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
