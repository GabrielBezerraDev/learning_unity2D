using Unity.VisualScripting;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public ItemPropertys itemPropertys;
    private Vector3 positionInMainCharacter = new Vector3(0.028f,-0.112f,0);
    private RectTransform rectTransform;
    // Start is called before the first frame update
    private Vector3 slotPosition = new Vector3(0,0,0);
    private Vector3 slotScale = new Vector3(0.66f,0.66f,0);
    private Vector3 slotRotation = new Vector3(0,0,0);
    private void Awake() {
        itemPropertys = gameObject.AddComponent<ItemPropertys>();   
    }
    void Start()
    {
        itemPropertys.setPosition(positionInMainCharacter);
        itemPropertys.setSlotPosition(slotPosition);
        itemPropertys.setSlotRotation(slotRotation);
        itemPropertys.setSlotScale(slotScale);
    }

    void Update()
    {
        if(!itemPropertys.isEquiped) return;
    }
}
