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
    public List<Image> imagesItems = new List<Image>();

    public GameObject slotsInventory;
    // Start is called before the first frame update
    void Start()
    {
        // slotsInventory =  GameObject.FindGameObjectsWithTag("itemInventory").ToList();
        getChildrens();
        foreach (Image image in imagesItems){
            item = new ItemInventory(image);
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

    public void getChildrens(){
        slotsInventory = GameObject.FindGameObjectWithTag("slots");
        Debug.Log(slotsInventory.transform.childCount);
        for(int i = 0; i < slotsInventory.transform.childCount; i++){
            Debug.Log(slotsInventory.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>());
            imagesItems.Add(slotsInventory.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>());
        }
    }


}