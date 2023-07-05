using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Inventory> items = new List<Inventory>();
    [System.Serializable]
    public struct Inventory
    {
        public ScriptableObject item;
    }

    public Image[] itemImage;
    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < items.Count; i++)
        // {
        //     var spritehid = items[i].item as Items;
        //     itemImage[i].sprite = spritehid.itemSpriteHidden;
        //     itemImage[i].GetComponent<Image>().color = Color.black;
        // }

        var Ruby = items[0].item as Items;
        var Sapphire = items[1].item as Items;
        var Emerald = items[2].item as Items;

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

    // Update is called once per frame
    void Update()
    {
        var Ruby = items[0].item as Items;
        var Sapphire = items[1].item as Items;
        var Emerald = items[2].item as Items;
        var brokenWand = items[3].item as Items;
        var wood = items[4].item as Items;

        

        if (Ruby.Completed == true)
        {
            itemImage[0].sprite = Ruby.itemSpriteHidden;
            itemImage[0].GetComponent<Image>().color = Color.white;
        }

        if (Sapphire.Completed == true)
        {
            itemImage[1].sprite = Sapphire.itemSpriteHidden;
            itemImage[1].GetComponent<Image>().color = Color.white;
        }

        if (Emerald.Completed == true)
        {
            itemImage[2].sprite = Emerald.itemSpriteHidden;
            itemImage[2].GetComponent<Image>().color = Color.white;
        }

        if (brokenWand.Completed == true)
        {
            itemImage[3].sprite = brokenWand.itemSpriteHidden;
            itemImage[3].GetComponent<Image>().color = Color.white;
        }

        if (wood.Completed == true)
        {
            itemImage[4].sprite = wood.itemSpriteHidden;
            itemImage[4].GetComponent<Image>().color = Color.white;
        }



        if (Ruby.Revealed == true && Ruby.Completed == false)
        {
            itemImage[0].sprite = Ruby.itemSpriteRevealed;
            itemImage[0].GetComponent<Image>().color = Color.white;
        }

        if (Sapphire.Revealed == true && Sapphire.Completed == false)
        {
            itemImage[1].sprite = Sapphire.itemSpriteRevealed;
            itemImage[1].GetComponent<Image>().color = Color.white;
        }

        if (Emerald.Revealed == true && Emerald.Completed == false)
        {
            itemImage[2].sprite = Emerald.itemSpriteRevealed;
            itemImage[2].GetComponent<Image>().color = Color.white;
        }

        if(brokenWand.Revealed == true && brokenWand.Completed == false)
        {
            itemImage[3].sprite = brokenWand.itemSpriteRevealed;
            itemImage[3].GetComponent<Image>().color = Color.white;
        }
    }

    public void Scroll1Completed()
    {
        var Ruby = items[0].item as Items;
        Ruby.Completed = true;
    }

    public void Scroll2Completed()
    {
        var Sapphire = items[1].item as Items;
        Sapphire.Completed = true;
    }

    public void Scroll3Completed()
    {
        var Emerald = items[2].item as Items;
        Emerald.Completed = true;
    }

    public void brokenWandCompleted()
    {
        var brokenWand = items[3].item as Items;
        brokenWand.Completed = true;
    }

    public void WoodCompleted()
    {
        var wood = items[4].item as Items;
        wood.Completed = true;
    }

    public void UnlockClue(string name)
    {
        if (name == "Scroll1")
        {
            var Ruby = items[0].item as Items;
            itemImage[0].sprite = Ruby.itemSpriteHidden;
            itemImage[0].GetComponent<Image>().color = Color.black;
            Ruby.Revealed = true;

        }
        if (name == "Scroll2")
        {
            var Sapphire = items[1].item as Items;
            itemImage[1].sprite = Sapphire.itemSpriteHidden;
            itemImage[1].GetComponent<Image>().color = Color.black;
            Sapphire.Revealed = true;
            
        }
        if (name == "Scroll3")
        {
            var Emerald = items[2].item as Items;
            itemImage[2].sprite = Emerald.itemSpriteHidden;
            itemImage[2].GetComponent<Image>().color = Color.black;
            Emerald.Revealed = true;
        }
    }

    public void Scroll1Clue()
    {
        var Scroll1 = items[0].item as Items;
        itemImage[0].sprite = Scroll1.itemSpriteRevealed;
        itemImage[0].GetComponent<Image>().color = Color.white;
        Scroll1.Revealed = true;
    }

    public void Scroll2Clue()
    {
        var Scroll2 = items[1].item as Items;
        itemImage[1].sprite = Scroll2.itemSpriteRevealed;
        itemImage[1].GetComponent<Image>().color = Color.white;
        Scroll2.Revealed = true;
    }

    public void Scroll3Clue()
    {
        var Scroll3 = items[2].item as Items;
        itemImage[2].sprite = Scroll3.itemSpriteRevealed;
        itemImage[2].GetComponent<Image>().color = Color.white;
        Scroll3.Revealed = true;
    }

    public void BrokenwandClue()
    {
        var brokenwand = items[3].item as Items;
        itemImage[3].sprite = brokenwand.itemSpriteRevealed;
        itemImage[3].GetComponent<Image>().color = Color.white;
        brokenwand.Revealed = true;
    }

}
