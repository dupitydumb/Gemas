using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsRedTrigger : MonoBehaviour
{
    public Animator anim;
    CharMove player;
    private bool ready;
    private bool single = true;

    public GameObject arrow;
    public Animator arrowanim;

    public GameObject scroll;
    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory Manager").GetComponent<InventoryManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
        arrowanim = arrow.GetComponent<Animator>();

        anim = GetComponent<Animator>();

        var quest = player.questManager;
        if (quest.questManager[7].isComplete)
        {
            anim.SetTrigger("cursed");
            
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
            if (Input.GetKey(KeyCode.W) && quest.questManager[5].isComplete)
            {
                anim.SetTrigger("Talk2");
                player.questManager.Quest8();
                Invoke("scrollactive", 10f);
                single = false;
                Destroy(arrow);
            }

            if (Input.GetKey(KeyCode.W) && quest.questManager[5].isComplete == false)
            {
                anim.SetTrigger("Talk");
                arrow.SetActive(false);
            }

        }
    }

    void scrollactive()
    {
        scroll.SetActive(true);
        inventoryManager.Scroll2Completed();
        inventoryManager.BrokenwandClue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
            Invoke("exit",1f);
        }
    }

    void exit()
    {
        arrow.SetActive(false);
    }
}
