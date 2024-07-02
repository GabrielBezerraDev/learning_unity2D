using System;
using UnityEngine;

public class ItemBehavior: MonoBehaviour, ProtocolItem {
    public bool isContainedInInvetory {get;set;} = false;
    public bool isEquiped {get;set;} = false;
    public Vector3 coordenatesPosition;
    public void setParent(Transform parent){
        transform.parent = parent;
    }

    public void setPosition(Vector3 postion){
        coordenatesPosition = postion;
    }

    public Vector3 getPosition(){
        return coordenatesPosition;
    }
}