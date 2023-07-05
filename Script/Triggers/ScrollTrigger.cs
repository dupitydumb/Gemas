using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTrigger : MonoBehaviour
{

    public GameObject Scroll;
    public GameObject Cam2;
    public GameObject ambatu;
    private bool ready;
    private bool alreadyOpen = false;
    public GameObject camera;

    public GameObject Char;
    CharMove player;

    public GameObject arrow;
    public Animator arrowanim;
    // Start is called before the first frame update
    void Start()
    {
        Char = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
        arrowanim = arrow.GetComponent<Animator>();

        var quest = player.questManager;

        if (quest.questManager[4].isComplete)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 anu = new Vector3(camera.transform.position.x,camera.transform.position.y, camera.transform.position.z +10);
        var quest = player.questManager;

        if (ready && !alreadyOpen)
        {
            if (Input.GetKey(KeyCode.W) )
            {
                Scroll.SetActive(true);
                Cam2.SetActive(true);
                ambatu.SetActive(false);
                Char.GetComponent<CharMove>().speed = 0f;
                Debug.Log("anu");
                ready = false;
                Destroy(arrow);
                player.questManager.Quest5();
            }


        }


    }

    void wait()
    {
        alreadyOpen = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var quest = player.questManager;
        if (collision.tag == "Player" && quest.questManager[2].isComplete)
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
