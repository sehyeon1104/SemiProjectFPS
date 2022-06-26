using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Vector3 bulletVector=new Vector3(0,0,0.1f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletVector);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
