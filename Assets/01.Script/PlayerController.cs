using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public  Vector3 move;
    CharacterController chcontroller;
    [SerializeField]
    int jumpPower = 10;
    [SerializeField]
    int speed = 5;
    [SerializeField]
    float gravity = 5;

    bool isWalk;
    public bool isRun;
    public bool isJump;
    void Start()
    {
        chcontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame  
    void Update()
    {
        isJump = false;
        isWalk = false;
        isRun = false;
        if(move.magnitude!=0)
        {
            isWalk = true;
        }
        if (chcontroller.isGrounded)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

             move = new Vector3(h, 0, v);
           move = transform.TransformDirection(move);
            if(Input.GetKeyDown(KeyCode.Space))
            {   
                isJump=true;
                move.y = jumpPower;
            }
            if(Input.GetKey(KeyCode.LeftShift)&&isWalk==true)
            {
                isRun = true;
                move.x*= 2.5f;
                move.z *= 2.5f;
            }
        }
        else
        {
            move.y-=gravity*Time.deltaTime;
        }
        chcontroller.Move(move*Time.deltaTime*speed);
    }
    
}
