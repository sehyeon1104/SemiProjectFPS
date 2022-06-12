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
        anim.SetBool("Jump", playerController.isJump);
    }
    void WalkAni()
    {
        anim.SetBool("Walk", playerController.move.magnitude != 0);
    }
    void RunAni()
    {
        anim.SetBool("Run",playerController.isRun);
    }
}
