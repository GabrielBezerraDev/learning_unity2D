using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public ItemBehavior itemBehavior;
    private Vector3 positionInMainCharacter = new Vector3(0.028f,-0.112f,0);

    // Start is called before the first frame update

    private void Awake() {
        itemBehavior = gameObject.AddComponent<ItemBehavior>();
    }
    void Start()
    {
        itemBehavior.setPosition(positionInMainCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        if(!itemBehavior.isEquiped) return;
    }
}
