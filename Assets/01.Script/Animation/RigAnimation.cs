using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class RigAnimation : MonoBehaviour
{
    bool isIdle;
    TwoBoneIKConstraint twoBone;
 public  Animator animator;

    void Start()
    {
        twoBone = GetComponent<TwoBoneIKConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
        isIdle = animator.GetBool("GunIdle");
       if(isIdle)
        {
            twoBone.weight = 1;
        }
        else
        {
            twoBone.weight = 0;
        }
    }
}
