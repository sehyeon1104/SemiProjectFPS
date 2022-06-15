using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
     
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
        anim.SetBool("Walk", playerController.isWalk);
        anim.SetFloat("Horizontal", playerController.h);
        anim.SetFloat("Vertical",playerController.v);
    }
    void RunAni()
    {
        anim.SetBool("Run",playerController.isRun);
    }
}
