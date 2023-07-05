using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCreampTrigger : MonoBehaviour
{
    private bool ready;
    public Animator anim;
    CharMove player;
    public bool sit = false;
    public GameObject arrow;
    public Animator arrowanim;

    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory Manager").GetComponent<InventoryManager>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
        var quest = player.questManager;
        arrowanim = arrow.GetComponent<Animator>();

        // Debug.Log(quest.questManager[0].questName);
        if (quest.questManager[2].isComplete)
        {
            anim.SetTrigger("nganu");
        }
    }

    // Update is called once per frame
    void Update()
    {
        var quest = player.questManager;

        if (ready && sit == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                sit = true;
                Destroy(arrow);
                anim.SetTrigger("Sit");
                player.questManager.Quest3();
                Invoke("clue", 12f);
            }

        }
    }

    void clue()
    {
        inventoryManager.Scroll1Clue();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ready = true;
            arrow.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            arrowanim.SetTrigger("Exit");
            ready = false;
            Invoke("exit", 0.5f);
        }
    }

    void exit()
    {
        arrow.SetActive(false);
    }
}
