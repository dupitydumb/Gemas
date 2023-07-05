using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BattleSystem : MonoBehaviour
{
    private GameObject player;
    private CharMove playerCs;
    public GameObject Villain;

    public TMP_Text playerHP;
    public TextMeshProUGUI timer;
    public Slider playerHPSlider;
    public Slider enemyHPSlider;


    public GameObject canvaAbra;
    public GameObject canvaDabra;
    public GameObject camerabattle;

    public float TimerCount = 15f;

    public bool isBattle = false;

    public int turn = 0;
    private BoxCollider2D bc;
    private Rigidbody2D rb;

    public enum BattleState{
        Start,
        PlayerTurn,
        EnemyTurn,
        Won,
        Lost
    }

    BattleState myState;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
        playerCs = player.GetComponent<CharMove>();
        timer.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer.text = Mathf.Round(TimerCount).ToString();
        TimerCount -= Time.deltaTime;

        // Kalo 10 detik ga ngetik apa2, HP berkurang 10
        if(TimerCount <= 0){
            TimerCount = 15f;
            playerCs.HP -= 10;

        }

        if(myState == BattleState.PlayerTurn){
            Debug.Log("Player Turn");
            playerHPSlider.gameObject.SetActive(true);
            enemyHPSlider.gameObject.SetActive(true);    }
        else{
            playerHPSlider.gameObject.SetActive(false);
            enemyHPSlider.gameObject.SetActive(false);
        }

        playerHPSlider.value = playerCs.HP;
        enemyHPSlider.value = Villain.GetComponent<Villian>().HP;



    }

    // Buat Munculin Canvas Abra
    public void PlayerTurn1(){
        myState = BattleState.PlayerTurn;
        timer.gameObject.SetActive(true);
        canvaAbra.SetActive(true);
        TimerCount = 15f;
    }

    // Buat Munculin Canvas Dabra
    public void PlayerTurn2(){
        myState = BattleState.PlayerTurn;
        timer.gameObject.SetActive(true);
        canvaDabra.SetActive(true);
        TimerCount = 15f;
    }



    void PlayerAttack(){
        Villain.GetComponent<Villian>().TakeDamage(playerCs.damage);
        myState = BattleState.EnemyTurn;
    }

    // Ganti Enemy attack
    public void EnemyTurn(){
        timer.gameObject.SetActive(false);
        Villain.GetComponent<Villian>().AttackPlayer();
    }

    public void BattleStart(){
        isBattle = true;
        camerabattle.SetActive(true);
        playerCs.FreezeMovement();
        PlayerTurn1();
        BattleState state = BattleState.Start;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            BattleStart();
        }
    }

}
