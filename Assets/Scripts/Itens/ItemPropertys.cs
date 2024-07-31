using UnityEngine;

public class ItemPropertys: MonoBehaviour, ProtocolItem {
    public bool isContainedInInvetory {get;set;} = false;
    public bool isEquiped {get;set;} = false;
    public Vector3 coordenatesPosition;
    public Vector3 slotScale {get;set;}
    public Vector3 slotPosition {get;set;}
    public Vector3 slotRotation {get;set;}


    public void setParent(Transform parent){
        transform.parent = parent;
    }

    public void setPosition(Vector3 postion){
        coordenatesPosition = postion;
    }

    public void setSlotRotation(Vector3 slotRotation ){
         this.slotRotation = slotRotation;
    }

    public void setSlotPosition(Vector3 slotPosition){
         this.slotPosition = slotPosition;
    }

    public void setSlotScale(Vector3 slotScale){
        this.slotScale = slotScale;
    }

    public Vector3 getPosition(){
        return coordenatesPosition;
    }

    public Vector3 getSlotPosition(){
        return slotPosition;
    }

    public Vector3 getSlotScale(){
        return slotScale;
    }
    
    public Vector3 getSlotRotation(){
        return slotRotation;
    }
}