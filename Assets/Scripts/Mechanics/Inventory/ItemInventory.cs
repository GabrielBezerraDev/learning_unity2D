using UnityEngine.UI;
using UnityEngine;
public class ItemInventory : ProtocolItemInventory{
    public GameObject item { get; set; }
    public GameObject spriteItem { get; set; }
    public ItemInventory(GameObject spriteItem){
        this.spriteItem = spriteItem;
    }
}