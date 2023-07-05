using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    BoxCollider2D playerbc;
    public string sceneName;
    public Vector3 spawnPoint;
    SceneManagement scenemanagement;
    public bool doors = true;

    public SavePos savepos;
    public GameObject arrow;
    public Animator arrowanim;

    public GameObject panel;
    public Animator panelanim;
    // Start is called before the first frame update
    void Start()
    {
        playerbc = GameObject.Find("Player_Boy").GetComponent<BoxCollider2D>();
        scenemanagement = GameObject.FindWithTag("SceneManagement").GetComponent<SceneManagement>();
        arrowanim = arrow.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // if (playerbc.IsTouching(GetComponent<BoxCollider2D>()))
        // {
        //     Debug.Log("Touched");
        //     savepos.startpoint = spawnPoint;
        //     scenemanagement.GoTo(sceneName);

        // }

        panelanim = panel.GetComponent<Animator>();

        if (Input.GetKeyDown(KeyCode.W) && playerbc.IsTouching(GetComponent<BoxCollider2D>()) && doors)
        {
            panelanim.SetTrigger("end");
            Invoke("TP", 0.5f);
        }

        if (playerbc.IsTouching(GetComponent<BoxCollider2D>()) && !doors)
        {
            panelanim.SetTrigger("end");
            Invoke("TP", 0.5f);
        }

        if(arrow == null)
        {
            ;
        }

    }

    void TP()
    {
        
        savepos.startpoint = spawnPoint;
        scenemanagement.GoTo(sceneName);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && doors)
        {
            arrow.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && doors)
        {

            arrowanim.SetTrigger("Exit");
            Invoke("exit", 0.5f); 
        }
    }

    void exit()
    {
        arrow.SetActive(false);
    }
}
