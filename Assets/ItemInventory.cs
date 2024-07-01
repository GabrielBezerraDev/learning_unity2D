using UnityEngine.UI;
using UnityEngine;
public class ItemInventory : ProtocolItemInventory{
    public GameObject item { get; set; }
    public Image spriteItem { get; set; }
    public ItemInventory(Image spriteItem){
        this.spriteItem = spriteItem;
    }
}