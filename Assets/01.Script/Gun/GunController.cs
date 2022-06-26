using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]
    ParticleSystem muzzleFlash;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject firePos;
    private void Awake()
    {
        audioSource =GetComponent<AudioSource>();
    }
    public void shootBullet()
    {
        print("½ðÈ½¼ö");
        Instantiate(prefab, firePos.transform.position, Quaternion.LookRotation(transform.forward)) ;
    }
    public void MuzzleShoot()
    {
        muzzleFlash.Play(); 
    }
    public void ShootMusic()
    { 
        audioSource.Play();
    }
}
