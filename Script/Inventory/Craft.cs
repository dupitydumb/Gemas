using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Craft : MonoBehaviour
{
    public ScriptableObject[] item;
    public ScriptableObject result;

    public Image[] itemImage;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<item.Length; i++)
        {
            var spritehid = item[i] as Items;
            itemImage[i].sprite = spritehid.itemSpriteHidden;
            itemImage[i].GetComponent<Image>().color = Color.black;
        }

        var Ruby = item[0] as Items;
        var Sapphire = item[1] as Items;
        var Emerald = item[2] as Items;

        if (Ruby.Completed == true)
        {
            itemImage[0].GetComponent<Image>().color = Color.white;
        }

        if (Sapphire.Completed == true)
        {
            itemImage[1].GetComponent<Image>().color = Color.white;
        }

        if (Emerald.Completed == true)
        {
            itemImage[2].GetComponent<Image>().color = Color.white;
        }


    }

    public void CraftItem()
    {
        var Ruby = item[0] as Items;
        var Sapphire = item[1] as Items;
        var Emerald = item[2] as Items;
        var Result = result as Items;

        if (Ruby.Completed == true && Sapphire.Completed == true && Emerald.Completed == true)
        {
            
            Debug.Log("Crafted");
            text.text = "Crafted";
        }
        else
        {
            
            text.text = "You don't have all the items";
        }
    }
}
