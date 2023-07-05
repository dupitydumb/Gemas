using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sworditems : MonoBehaviour
{
    BoxCollider2D playerbc;
    // Start is called before the first frame update
    void Start()
    {
        playerbc = GameObject.Find("Player").GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerbc.IsTouching(GetComponent<BoxCollider2D>()))
        {
            Debug.Log("Touched");
            transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
