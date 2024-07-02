using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grenade : MonoBehaviour, ProtocolItem
{
    public bool isContainedInInvetory {get;set;} = false;
    public bool isEquiped {get;set;} = false;
    public ItemBehavior itemBehavior;
    // Start is called before the first frame update

    private void Awake() {
        itemBehavior = this.AddComponent<ItemBehavior>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!itemBehavior.isEquiped) return;
    }
}
