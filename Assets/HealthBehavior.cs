using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour
{
    private float lifeCharacter = 1f;
    private int life = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Damage")]
    public void damageCharacter(float percentageOfLife)
    {
        GetComponent<Slider>().value = GetComponent<Slider>().value - (lifeCharacter - ((lifeCharacter * (life - percentageOfLife)) / life));
    }
}
