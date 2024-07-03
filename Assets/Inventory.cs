using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{   
    public ItemInventory item;
    public List<ItemInventory> inventoryItems = new List<ItemInventory>();
    public List<GameObject> slotsInventory = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        slotsInventory =  GameObject.FindGameObjectsWithTag("itemInventory").ToList();
        foreach (GameObject slot in slotsInventory){
            item = new ItemInventory(slot.GetComponent<Image>());
            inventoryItems.Add(item);
        }
        // Debug.Log($"Quantidade de slots no inventory: {inventoryItems.Count} ");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddInventoryItem(GameObject item){
        foreach(ItemInventory slotItem in inventoryItems){
            if(!slotItem.item && !item.GetComponent<ItemBehavior>().isContainedInInvetory) {
                item.GetComponent<ItemBehavior>().isContainedInInvetory = true;
                slotItem.item = item;
                slotItem.spriteItem.sprite = item.GetComponent<SpriteRenderer>().sprite;
                break;
            }
        }

    }


}