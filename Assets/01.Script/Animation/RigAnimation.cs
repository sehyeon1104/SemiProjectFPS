using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class RigAnimation : MonoBehaviour
{
    TwoBoneIKConstraint twoBone;
    public PlayerController playerController;

    void Start()
    {
        twoBone = GetComponent<TwoBoneIKConstraint>();
    }

    // Update is called once per frame
    void Update()
    {
       
       if(playerController.move.x==0&&playerController.move.z==0)
        {
            twoBone.weight = 1;
        }
        else
        {
            twoBone.weight = 0;
        }
    }
    
}
