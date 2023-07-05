using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll1 : MonoBehaviour
{
    public GameObject anu;
    public Animator anim;
    public GameObject Cam2;
    public GameObject arrow;
    public GameObject ambatu;

    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory Manager").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anu == null)
        {
            anim.SetTrigger("Complete");
            Invoke("crot", 4f);
            ambatu.SetActive(true);
            Destroy(Cam2);
            Destroy(arrow);
            inventoryManager.Scroll1Completed();
        }
    }

    void crot()
    {
        
        Destroy(gameObject);
    }
}
