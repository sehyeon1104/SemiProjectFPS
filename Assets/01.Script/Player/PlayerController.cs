using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public ZombieKillText zombiekilltext;
   public Scrollbar m_Scrollbar;
    public TextMeshProUGUI destination;
    int currentBullet = 30;
    public int CurrentBullet { get => currentBullet; set { currentBullet = value; } }
    float timer = 0;
    [field: SerializeField] UnityEvent Shoot;
    [field: SerializeField] UnityEvent Reload;
    public float hp = 100;
    float maxHp = 100;
     float h,v;
    public float H { get => h; }
    public float V { get => v; }
     Vector3 move;
    public Vector3 Move { get => move; set { move = value; } }
    [SerializeField]
    GameObject waterFall;
    [SerializeField]
    GameObject[] fireGroup;

   public GunController gunController;
    CharacterController chcontroller;
    [SerializeField]
    float jumpPower = 10;
    [SerializeField]
    int speed = 5;
    [SerializeField]
    float gravity = 5;
    bool isShoot;
     bool isWalk;
    bool isRun;
    bool isJump;

    
    public bool IsWalk { get => isWalk; set { isWalk = value; } }
     public bool IsRun { get => isRun; set { isRun = value; } }
   public bool IsJump { get => isJump; set { isJump = value; } }
    void Start()
    {

        chcontroller = GetComponent<CharacterController>();
    }

    // Update is called once per frame  
    void Update()
    {
        PlayerHP();
        
        if(Input.GetKeyDown(KeyCode.R))
        {
            ReloadBullet();
        }
        if(Input.GetMouseButtonDown(0))
        {
            Onshoot();
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10))
            {
                if(hit.transform.gameObject.CompareTag("TriggerButton"))
                {
                    destination.text = "긴급 소화가 시작됩니다";
                    StartCoroutine(OffFire());
                }
            }
        }
        timer += Time.deltaTime;
        if (timer > 0.2f)
        {
            isShoot = true;
        }
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
            if (Input.GetKeyDown(KeyCode.LeftShift)||Input.GetKey(KeyCode.LeftShift) && (move.x != 0 || move.z != 0))
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
    void Onshoot()
    {
      
        if (move.x==0&&move.z==0&&isShoot)
        {
            if (currentBullet <= 0)
            {
                print("d");
                gunController.NoBullet();
                return;
            }
            currentBullet--;
            Shoot?.Invoke();
            isShoot = false;
            timer = 0;
        }
    }
    void ReloadBullet()
    {
            Reload?.Invoke(); 
    }
    
    IEnumerator OffFire()
    {
        yield return new WaitForSeconds(5f);
        WaitForSeconds waitForSeconds = new WaitForSeconds(4f);
        waterFall.SetActive(true);
        yield return waitForSeconds;
        foreach (GameObject game in fireGroup)
        {
            game.SetActive(false);
        }
        yield return waitForSeconds;
        destination.text = "성공하셨습니다";
        destination.fontSize += 20;
    }
    void PlayerHP()
    {
        m_Scrollbar.size = hp/maxHp;
    }
}
    