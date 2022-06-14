using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float h,v;
    public Vector3 move;
    CharacterController chcontroller;
    [SerializeField]
    int jumpPower = 10;
    [SerializeField]
    int speed = 5;
    [SerializeField]
    float gravity = 5;

    public bool isWalk;
    public bool isRun;
    public bool isJump;
    void Start()
    {
        chcontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame  
    void Update()
    { 
        isWalk = false;
      
        isRun = false;
        if ((move.x != 0 || move.z != 0) && (move.y == 0))
        {
            isWalk = true;

        }
        if (chcontroller.isGrounded)
        {
             h = Input.GetAxisRaw("Horizontal");
             v = Input.GetAxisRaw("Vertical");

            move = new Vector3(h, 0, v);

            move = transform.TransformDirection(move);
            move.Normalize();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                move.y = jumpPower;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKey(KeyCode.LeftShift) && (move.x != 0 || move.z != 0))
            {
                
                isWalk = false;
                isRun = true;
                move.x *= 2.5f;
                move.z *= 2.5f;
            }
        }
        else
        {
            move.y -= gravity * Time.deltaTime;
        }

        chcontroller.Move(move * Time.deltaTime * speed);
    }

}
