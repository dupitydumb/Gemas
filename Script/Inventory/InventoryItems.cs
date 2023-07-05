using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItems : MonoBehaviour
{
    private InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        inventoryManager = GameObject.FindGameObjectWithTag("Inventory Manager").GetComponent<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver() {
        var Ruby = inventoryManager.items[0].item as Items;
        var Sapphire = inventoryManager.items[1].item as Items;
        var Emerald = inventoryManager.items[2].item as Items;
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Clicked" + gameObject.name);

            if (gameObject.name == "Scroll1" && Ruby.Revealed == true) {
                AddScroll1();
                inventoryManager.Scroll1Completed();
                Debug.Log("scroll Added");
                Destroy(gameObject);
            }
            if (gameObject.name == "Scroll2" && Sapphire.Revealed == true) {
                AddScroll2();
                inventoryManager.Scroll2Completed();
                Debug.Log("Sapphire Added");
                Destroy(gameObject);
            }
            if (gameObject.name == "Scroll3" && Emerald.Revealed == true) {
                AddScroll3();
                inventoryManager.Scroll3Completed();
                Debug.Log("Emerald Added");
                Destroy(gameObject);
            }
        }
    }


    public void AddScroll1() {
        inventoryManager.itemImage[0].GetComponent<Image>().color = Color.white;
    }

    public void AddScroll2() {
        inventoryManager.itemImage[1].GetComponent<Image>().color = Color.white;
    }

    public void AddScroll3() {
        inventoryManager.itemImage[2].GetComponent<Image>().color = Color.white;
    }
}
