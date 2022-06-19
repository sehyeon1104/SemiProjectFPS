using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
public class LookAtObjectRigging : MonoBehaviour
{
    Rig rig;
    public float targetWeight;
    private void Awake()
    {
      rig=  GetComponent<Rig>();
    }
    private void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime*10f);

        if(Input.GetKeyDown(KeyCode.T))
        {   

        }
    }
}
