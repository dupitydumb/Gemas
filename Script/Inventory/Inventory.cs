using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public struct itemsinv
    {
        public bool Completed;
        public GameObject item;
    }

    public List<itemsinv> items = new List<itemsinv>();

    public List<Image> DisplayImages = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        UpdateInventory();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void UpdateInventory()
    {
        for (int i = 0; i < items.Count; i++)
        {
            DisplayImages[i].GetComponent<Image>().sprite = items[i].item.GetComponent<SpriteRenderer>().sprite;
            Debug.Log("Updated");
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].Completed == true)
            {
                DisplayImages[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                DisplayImages[i].GetComponent<Image>().color = Color.white;
            }
        }
    }
    
     

}
