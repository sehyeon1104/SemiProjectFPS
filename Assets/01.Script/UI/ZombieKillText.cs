using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZombieKillText : MonoBehaviour
{
    TextMeshProUGUI zombieText;
    public ZombieController zombieController;
    public GameObject[] zombie;
    // Start is called before the first frame update
    void Start()
    {
        zombieText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
       zombie = GameObject.FindGameObjectsWithTag("Zombie");
       
        zombieText.text = $"살아있는 좀비의 수:{zombie.Length}";
    }
}
