using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float runSpeed = 100f;
    float horizontalMove = 0f;

    public int totalJumps = 2;

    int availableJumps;
    bool jump = false;

    bool fastFall = false;
    public int jumpsquat = 8;
    int shortHopBuffer = 0;

    int shortHopWait = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButton("Jump") || Input.GetAxisRaw("Vertical") == 1)
        {

            shortHopBuffer++;

            if (shortHopBuffer >= jumpsquat)
            {
                // do big jump
                jump = true;
                shortHopBuffer = 0;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (shortHopBuffer <= jumpsquat)
            {
                shortHopWait = jumpsquat - shortHopBuffer;
                // do small jump
                jump = true;

                shortHopBuffer = 0;
            }
        }



        if (Input.GetAxisRaw("Vertical") == -1)
        {
            fastFall = true;

        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (shortHopWait != 0)
        {
            jump = false;
            shortHopWait--;

            if (shortHopWait == 0)
            {

                controller.Move(horizontalMove * Time.fixedDeltaTime, fastFall, true);
                jump = false;
                fastFall = false;
                return;
            }
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, fastFall, jump);
        jump = false;
        fastFall = false;
    }
}
