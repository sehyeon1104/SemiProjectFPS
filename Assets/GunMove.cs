using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    Rigidbody gunrigid;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        gunrigid=GetComponent<Rigidbody>();
    }
    public void GunShoot(Vector3 dir)
    {
    direction = dir;
        Destroy(gameObject,5f);
    }
    // Update is called once per frame
    void Update()
    {
        gunrigid.velocity=direction;
    }
}
