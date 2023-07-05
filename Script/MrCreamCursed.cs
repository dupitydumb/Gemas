using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MrCreamCursed : MonoBehaviour
{
    private bool ready;
    public Animator anim;

    CharMove player;
    public GameObject Firef;
    bool single = true;

    public GameObject arrow;
    public Animator arrowanim;

    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory Manager").GetComponent<InventoryManager>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
        arrowanim = arrow.GetComponent<Animator>();

        var quest = player.questManager;
        if (quest.questManager[5].isComplete)
        {
            anim.SetTrigger("Cursed");
            Destroy(Firef);
            Destroy(arrow);
            single = false;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        var quest = player.questManager;

        if (ready && single)
        {
            if(Input.GetKey(KeyCode.W) && quest.questManager[4].isComplete)
            {
                anim.SetTrigger("Talk");
                player.questManager.Quest6();
                Invoke("FireF", 5.3f);
                single = false;
                Destroy(arrow);
            }
        }
    }

    void FireF()
    {
        Firef.SetActive(true);
        inventoryManager.Scroll2Clue();
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
