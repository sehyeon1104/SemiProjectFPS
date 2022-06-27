using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public int zombieKill = 0;
    public AudioClip dieclip;
    AudioSource audioSource;
    [SerializeField]
   public CapsuleCollider capsuleCollider;
    int hp = 100;
    Vector3 a;
    [SerializeField]
    [Range(0f, 20f)]
    float zombieSpeed = 2f;
    Rigidbody zombieRigid;
    float timer = 0;
    Animator zombieAnimation;
    bool zombieDie=true;
    private readonly int hashWalk = Animator.StringToHash("IsZombieWalk");
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        zombieRigid = GetComponent<Rigidbody>(); 
        zombieAnimation = GetComponent<Animator>();
        StartCoroutine(DirChange());
    }

    void Update()
    {
        
        if(hp<=0)
        {
            Die();
        }
    }

    private void Die()
    {
        if(zombieDie)
        {
            hp++;
            audioSource.clip = dieclip;
            audioSource.Play();
            capsuleCollider.direction = 2;
        zombieAnimation.SetTrigger("Die");    
        Destroy(gameObject, 5f);
            zombieDie = false;
        }
    }

    void Walk()
    {
        audioSource.Play();
        int randomPos = Random.Range(0, 4);
        print(randomPos);
        while (timer < 10)
        {
            timer += Time.deltaTime;
            zombieAnimation.SetBool(hashWalk, true);
            if (randomPos == 0)
            {
                zombieRigid.velocity = transform.forward*zombieSpeed*Time.deltaTime;
            }
            else if (randomPos == 1)
            {
               zombieRigid.velocity -= transform.forward* zombieSpeed*Time.deltaTime;
            }
            else if (randomPos == 2)
            {
                zombieRigid.velocity = transform.right*zombieSpeed * Time.deltaTime; //오른쪽으로
            }
            else
            {
                zombieRigid.velocity -= transform.right*zombieSpeed * Time.deltaTime; // 왼쪽으로
            }
        }
      
        zombieAnimation.SetBool(hashWalk, false);
        timer = 0;
    }

    IEnumerator DirChange()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(10);
        while(true)
        {
            Walk();
            yield return waitForSeconds;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 30;
        }
    }
}


