using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BulletScript : MonoBehaviour
{
    public PlayerController playerController;
  public  GunController gunController;
    TextMeshProUGUI bulletTMP;
    // Start is called before the first frame update
    void Start()
    {
        bulletTMP = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        bulletTMP.text = $"{playerController.CurrentBullet}/{gunController.MaxBullet}";
    }
   
}
