using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guncontroller : MonoBehaviour
{
    GameObject firePos;
    GameObject bullet;
    private void Start()
    {
        firePos = transform.GetChild(0).gameObject;
        bullet = Resources.Load<GameObject>("Bullet/GunBullet");
    }
    public void GoBullet()
    {
        var f = Instantiate(bullet, firePos.transform.position, Quaternion.identity).GetComponent<GunMove>();
        f.GunShoot()
    }
}