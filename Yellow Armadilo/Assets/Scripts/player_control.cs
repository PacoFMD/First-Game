using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_control : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb2d;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadious;
    public LayerMask whatIsGrounded;

    private int extraJumps;
    public int extraJumpValue;

    private void Start()
    {
        extraJumps = extraJumpValue;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadious, whatIsGrounded);
        moveInput = Input.GetAxis("Horizontal");

        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);

        //player run
        Vector2 moveVector = rb2d.velocity;
        if (Input.GetKey(KeyCode.LeftShift)){
            moveVector.x = moveInput * 2f * speed;
        }else{
            moveVector.x = moveInput * speed;
        }
        rb2d.velocity = moveVector;

        //Facing Direction
        if(facingRight == false && moveInput > 0){
            Flip();
        }else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()//Funcion Girar
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void Jump()//Funcion Saltar
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpValue;
        }
        if(Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb2d.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }else if(Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded == true)
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }
    }
}
