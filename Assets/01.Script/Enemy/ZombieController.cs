using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{

    [SerializeField]
    [Range(0f, 20f)]
    float zombieSpeed = 2f;

    float timer = 0;
    Animator zombieAnimation;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        zombieAnimation = GetComponent<Animator>();
        StartCoroutine(DirChange());
    }

    void Update()
    {
      
    }
    void Walk()
    {

        int randomPos = Random.Range(0, 4);
        print(randomPos);
        while (timer < 10)
        {
            timer += Time.deltaTime;
            zombieAnimation.SetBool("IsZombieWalk", true);
            if (randomPos == 0)
            {
               
                rb.velocity = new Vector3(0, 0, zombieSpeed); // 앞쪽으로
            }
            else if (randomPos == 1)
            {
                rb.velocity = new Vector3(0, 0, -zombieSpeed); //뒷쪽으로
            }
            else if (randomPos == 2)
            {
                //transform.localEulerAngles = new Vector3(0, 90, 0);
                rb.velocity = new Vector3(zombieSpeed, 0, 0); //오른쪽으로
            }
            else
            {
                //transform.localEulerAngles = new Vector3(0, -90, 0);
                rb.velocity = new Vector3(-zombieSpeed, 0, 0); // 왼쪽으로
            }
        }
        zombieAnimation.SetBool("IsZombieWalk", false);
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
}


