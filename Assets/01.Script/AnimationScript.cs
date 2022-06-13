using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
   
        Vector3 move=new Vector3(0,0,0);    
    PlayerController playerController;
   Animator anim;
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RunAni();
        WalkAni();
        Jump();
    }
    void Jump()
    {
        if(playerController.isJump==true)
        {
            anim.SetTrigger("Jump");
            playerController.isJump = false;
        }

    }
    void WalkAni()
    {
         move = transform.InverseTransformDirection(playerController.move);
        anim.SetBool("Walk", playerController.isWalk);
        anim.SetFloat("WalkSpeed", move.z > 0 ? 1 : -1);
    }
    void RunAni()
    {
        anim.SetBool("Run",playerController.isRun);
    }
}
