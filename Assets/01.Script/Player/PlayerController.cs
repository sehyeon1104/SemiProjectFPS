using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerController : MonoBehaviour
{
    [field: SerializeField] UnityEvent OnShoot;

     float h,v;
    public float H { get => h; }
    public float V { get => v; }
     Vector3 move;
    public Vector3 Move { get => move; }
    CharacterController chcontroller;
    [SerializeField]
    float jumpPower = 10;
    [SerializeField]
    int speed = 5;
    [SerializeField]
    float gravity = 5;

   
     bool isWalk;
    public bool Iswalk { get => isWalk;  }
    
     bool isRun;
    public bool IsRun { get=>isRun;}
     bool isJump;
    public bool IsJump { get => isJump; set { isJump = value; } }
    void Start()
    {
        chcontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame  
    void Update()
    {
        Shoot();
        MovePlayer();
    }
    void MovePlayer()
    {
        isWalk = false;
        isRun = false;
        if ((move.x != 0 || move.z != 0) && (move.y == 0))
        {
            isWalk = true;

        }
        if (chcontroller.isGrounded)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            move = new Vector3(h, 0, v);

            move = transform.TransformDirection(move);
            move.Normalize();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                move.y = jumpPower;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftShift) && (move.x != 0 || move.z != 0))
            {

                isWalk = false;
                isRun = true;
                move.x *= 2.5f;
                move.z *= 2.5f;
            }
        }
        else
        {
            move.y -= gravity * Time.deltaTime;
        }

        chcontroller.Move(move * Time.deltaTime * speed);
    }
    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }

}
    