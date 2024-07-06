using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class Inventory : MonoBehaviour
{   
    public ItemInventory item;
    public List<ItemInventory> inventoryItems = new List<ItemInventory>();
    public List<GameObject> imagesItems = new List<GameObject>();

    public Vector3 slotPosition;
    public Vector3 slotScale;
    public Vector3 slotRotation;
    public GameObject slotsInventory;
    public  GameObject currentItem;
    public int enumDigit = 49;
    void Start()
    {
        getChildrens();
        foreach (GameObject image in imagesItems){
            item = new ItemInventory(image);
            inventoryItems.Add(item);
        }
    }

    void Update()
    {
        triggerKeyNumber();
    }

    public void AddInventoryItem(GameObject item){
        foreach(ItemInventory slotItem in inventoryItems){
            if(!slotItem.item && !item.GetComponent<ItemPropertys>().isContainedInInvetory) {
                item.GetComponent<ItemPropertys>().isContainedInInvetory = true;
                slotItem.item = item;
                slotItem.spriteItem.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
                slotItem.spriteItem.GetComponent<RectTransform>().localPosition = slotPosition;
                slotItem.spriteItem.GetComponent<RectTransform>().localScale = slotScale;
                slotItem.spriteItem.GetComponent<RectTransform>().localEulerAngles = slotRotation;
                break;
            }
        }

    }

    public void setSlotPosition(Vector3 slotPosition){
        this.slotPosition = slotPosition;
    }

    public void setSlotScale(Vector3 slotScale){
        this.slotScale = slotScale;
    }

    public void setSlotRotation(Vector3 slotRotation){
        this.slotRotation = slotRotation;
    }

    public void equipedItem(int slot){
        if(inventoryItems[slot].item){
            if(currentItem) currentItem.SetActive(false); 
            currentItem = inventoryItems[slot].item.gameObject;
            currentItem.SetActive(true);
        }
    }

    public void triggerKeyNumber(){
        for(int i = 0; i < inventoryItems.Count; i++){
            if(Input.GetKeyUp((KeyCode) Enum.ToObject(typeof(KeyCode),enumDigit+i))){
                equipedItem(i);
                return;
            }
        }
    }

    public void getChildrens(){
        slotsInventory = GameObject.FindGameObjectWithTag("slots");
        Debug.Log(slotsInventory.transform.childCount);
        for(int i = 0; i < slotsInventory.transform.childCount; i++){
            Debug.Log(slotsInventory.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>());
            imagesItems.Add(slotsInventory.transform.GetChild(i).transform.GetChild(0).gameObject);
        }
    }

}