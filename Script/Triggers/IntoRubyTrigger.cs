using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoRubyTrigger : MonoBehaviour
{
    private bool ready;
    public GameObject fireF;
    CharMove player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CharMove>();
        var quest = player.questManager;
        if (quest.questManager[6].isComplete)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (fireF == null)
        {
            ;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var quest = player.questManager;
        if (collision.tag == "Player" && quest.questManager[5].isComplete)
        {
            ready = true;
            fireF.SetActive(true);
            
            player.questManager.Quest7();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ready = false;
        }
    }
}
