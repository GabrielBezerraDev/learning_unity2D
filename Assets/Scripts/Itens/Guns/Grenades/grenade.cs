using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public ItemPropertys itemPropertys;
    private Vector3 positionInMainCharacter = new Vector3(0.028f,-0.112f,0);

    // Start is called before the first frame update

    private void Awake() {
        itemPropertys = gameObject.AddComponent<ItemPropertys>();
    }
    void Start()
    {
        itemPropertys.setPosition(positionInMainCharacter);
    }

    // Update is called once per frame
    void Update()
    {
        if(!itemPropertys.isEquiped) return;
    }
}
