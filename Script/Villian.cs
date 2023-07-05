using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villian : MonoBehaviour
{

    public int HP = 20;
    public int Attack = 10;

    public GameObject player;
    public CharMove playerCs;
    BattleSystem battleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCs = player.GetComponent<CharMove>();
        battleSystem = GameObject.FindWithTag("BattleSystem").GetComponent<BattleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage){
        HP -= damage;

    }

    public void AttackPlayer(){

        // Animasi attack disini bang
        // __________________________ //


        playerCs.TakeDamage(Attack);

        // Balik nampilin letter
        battleSystem.PlayerTurn2();

    }


}
