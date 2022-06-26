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
        if(playerController.IsJump==true)
        {
            anim.SetTrigger("Jump");
            playerController.IsJump = false;
        }

    }
    void WalkAni()
    {
        anim.SetBool("Walk", playerController.IsWalk);
        anim.SetFloat("Horizontal", playerController.H);
        anim.SetFloat("Vertical",playerController.V);
    }
    void RunAni()
    {
        anim.SetBool("Run",playerController.IsRun);
    }
}
