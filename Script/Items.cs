using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class Items : ScriptableObject
{
    public string itemName;
    public Sprite itemSpriteHidden;
    public Sprite itemSpriteRevealed;
    public Sprite none;
    public bool Completed = false;
    public bool Revealed = false;
    public bool crafted1 = false;
    public bool crafted2 = false;
    


}

