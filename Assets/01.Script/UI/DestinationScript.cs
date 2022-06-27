using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DestinationScript : MonoBehaviour
{
    public ZombieKillText zombieKillText;
    BoxCollider boxCollider;
  public  TextMeshProUGUI destinationText;
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
                 
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player")&&zombieKillText.zombie.Length==0)
        {
            destinationText.text = "��ư�� ���� ���� ���ÿ�";
            boxCollider.enabled = false;
        }
    }

}
