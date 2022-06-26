using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DestinationScript : MonoBehaviour
{
  public  TextMeshProUGUI destinationText;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
                 
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            destinationText.text = "버튼을 눌러 불을 끄시오";
        }
    }

}
