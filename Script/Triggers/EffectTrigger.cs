using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    //public GameObject Vfx1;
    //public GameObject Vfx2;
    public GameObject group;
    CharMove player;

    Animator anim;
    public GameObject canvas;
    private bool ready;
    private bool alreadyOpen = false;

    public GameObject arrow;
    public Animator arrowanim;
    private bool single = true;
    // Start is called before the first frame update
    void Start()
    {
        //playerbc = GameObject.FindWithTag("Player").GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        arrowanim = arrow.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();

        var quest = player.questManager;
        if (quest.questManager[8].isComplete)
        {

            Destroy(canvas);
            Destroy(arrow);
            single = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        var quest = player.questManager;
        if (ready && single == true && !alreadyOpen && quest.questManager[8].isComplete == false)
        {
            if (Input.GetKey(KeyCode.W))
            {
                canvas.SetActive(true);
                group.SetActive(false);
                Debug.Log("anu");
                ready = false;
                single = false;
                player.questManager.Quest9();
                arrow.SetActive(false);
            }

        }

        if(arrow == null)
        {
            ;
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {

            anim.SetBool("Glow", true);
            ready = true;
            arrow.SetActive(true);
            //Instantiate(Vfx1, transform.position, Quaternion.identity);
            //Instantiate(Vfx2, transform.position, Quaternion.identity);


        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("Glow", false);
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
