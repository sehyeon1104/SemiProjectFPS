using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public AudioClip shootSound;
    public AudioClip reloadSound;
    public AudioClip noBulletSound;
    int howShoot = 30;
    int maxBullet = 60;
    public int MaxBullet { get => maxBullet; set { maxBullet = value; } }
    public PlayerController playerController;
    AudioSource audioSource;
    [SerializeField]
    ParticleSystem muzzleFlash;
    [SerializeField]
    GameObject prefab;
    [SerializeField]
    GameObject firePos;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {

    }
    public void ShootBullet()
    {

        Instantiate(prefab, firePos.transform.position, Quaternion.LookRotation(transform.forward));
        audioSource.clip = shootSound;
        audioSource.Play();
        muzzleFlash.Play();
    }  
    public void ReloadGun()
    {
        if(maxBullet<=0)
        {
            return;
        }
        audioSource.clip = reloadSound;
        audioSource.Play();
        Invoke("ReloadBullet", 0.5f);
            
    }
    void ReloadBullet()
    {
        playerController.CurrentBullet = 30;
        maxBullet -= howShoot;
    }
    public void NoBullet()
    {
        audioSource.clip = noBulletSound;

        audioSource.Play();
    }
    
}
