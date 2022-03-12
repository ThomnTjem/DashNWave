using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float runSpeed = 40f;
    float horizontalMove=0f;
    bool jump = false;

    bool fastFall = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if(Input.GetButtonDown("Jump")){
         jump=true;
        }

        if(Input.GetAxisRaw("Vertical")==-1){
            fastFall = true;
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,fastFall,jump);
        jump=false;
        fastFall=false;
    }
}
