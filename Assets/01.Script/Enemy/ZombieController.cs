using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    int RandomPos = 0;
    [SerializeField]
    [Range(0f, 10f)]
    float zombieSpeed = 2f;

    float timer = 0;
    Animator zombieAnimation;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        zombieAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        Walk();
    }
    void Walk()
    {
       
      int randomPos = Random.Range(0, 4);
        print(randomPos);
        timer += Time.deltaTime;
        print(timer);
        if(timer >=10)
        {
            float timea = 0;
            timea += Time.deltaTime;
            
            zombieAnimation.SetBool("IsZombieWalk",true);
            if(randomPos==0)
            {
                rb.velocity = new Vector3(0, 0, zombieSpeed); // 앞쪽으로
            }
            else if(randomPos==1)
            {
                rb.velocity = new Vector3(0, 0, -zombieSpeed); //뒷쪽으로
            }
            else if(randomPos==2)
            {
                rb.velocity=new Vector3(zombieSpeed, 0, 0); //오른쪽으로
            }
            else
            {
                rb.velocity = new Vector3(-zombieSpeed, 0, 0); // 왼쪽으로
            }
            zombieAnimation.SetBool("IsZombieWalk", false);
        }    
    }
}
