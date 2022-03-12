using System.Collections;


using System.Collections.Generic;

using UnityEngine;



public class CharacterController2D: MonoBehaviour

{

    [Header("Components")]

    private Rigidbody2D rb;

    public float speed;

    public float jumpForce;

    private float moveInput;



    [Header("Layar Mask")]

    private bool isGrounded;

    public Transform feetPos;

    public float checkRadius;

    public LayerMask whatIsGround;



    [Header("Jump")]

    private float jumpTimeCounter;

    public float jumpTime;

public int extraJumpValue;
private int extraJumps;
    private bool isJumping;



    [Header("fall physics")]

    public float fallMultiplier;

    public float lowJumpMultiplier;





    //Gets Rigidbody component

    void Start()

    {

        rb = GetComponent<Rigidbody2D>();
        extraJumps = extraJumpValue;

    }



    //Moves player on x axis

    void FixedUpdate()

    {

        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    }





    

    void Update()

    {

    



        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

if(isGrounded){
    extraJumps = extraJumpValue;
}


        //turn twords you go

        if (moveInput > 0)

        {

            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        else if (moveInput < 0)

        {

            transform.eulerAngles = new Vector3(0, 180, 0);

        }



        //cool jump fall

        if (rb.velocity.y < 0)

        {

            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;

        }

        else if (rb.velocity.y > 0 && Input.GetKey(KeyCode.Space))

        {

            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;

        }



       //fixed double jump bug

        if (Input.GetKeyUp(KeyCode.Space))

        {

            isJumping = false;

        }



        //lets player jump

        if (Input.GetKeyDown("space") && extraJumps > 0)

        {

            isJumping = true;

            jumpTimeCounter = jumpTime;

            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;

        }



        //makes you jump higher when you hold down space

        if (Input.GetKey(KeyCode.Space) && isJumping == true) {

            if (jumpTimeCounter > 0) {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;

            } else {
                isJumping = false;
            }



            

        }

        

    } 

    

}