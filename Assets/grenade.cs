using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grenade : MonoBehaviour
{

    public ItemBehavior itemBehavior;
    // Start is called before the first frame update
    void Start()
    {
        itemBehavior = this.AddComponent<ItemBehavior>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!itemBehavior.isEquiped) return;
    }
}
