using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj1Trigger : MonoBehaviour
{
    private bool ready;
    public GameObject fireF;
    CharMove player;

    public GameObject arrow;
    public Animator arrowanim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
        arrowanim = arrow.GetComponent<Animator>();

        var quest = player.questManager;
        if (quest.questManager[1].isComplete)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var quest = player.questManager;

        if (ready)
        {
            if (Input.GetKey(KeyCode.W))
            {
                           
                ready = false;
                fireF.SetActive(true);
                Destroy(gameObject, 0.5f);
                player.questManager.Quest2();
            }

        }

        if (quest.questManager[2].isComplete)
        {
            Destroy(gameObject);
        }
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
