using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void setSlider(Slider slider)
    {
        this.slider = slider;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<bulletScript>())
        {
            bulletScript bullet = collision.gameObject.GetComponent<bulletScript>();
            if (bullet.damage > 0)
            {
                damageCharacter(bullet.damage);
                //Debug.Log(bullet.damage);
            }
        }
    }
    [ContextMenu("DamageCharacter")]
    public void damageCharacter(float percentageOfLife)
    {
        this.slider.value = this.slider.value - ((1f * percentageOfLife)/100);
    }
}
