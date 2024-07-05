using UnityEngine;

public interface ProtocolItem{
    bool isContainedInInvetory {get;set;} 
    bool isEquiped {get;set;}
    Vector3 slotScale {get;set;}
    Vector3 slotPosition {get;set;}
}