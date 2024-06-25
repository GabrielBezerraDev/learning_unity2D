using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCharacter : MonoBehaviour
{

    private HealthBarScript healthBar;
    // Start is called before the first frame update

    private void Awake()
    {
        HealthBarScript healthBar = gameObject.AddComponent<HealthBarScript>();
        healthBar.setSlider((gameObject.GetComponentInChildren<Canvas>()).GetComponentInChildren<Slider>());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setSprite(Sprite spriteCharacter)
    {
        GetComponent<SpriteRenderer>().sprite = spriteCharacter;
    }

}
