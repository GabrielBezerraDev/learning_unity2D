using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemplateCharacter : HealthBarScript
{
    protected Slider slider;
    protected Image image;

    protected void setHealthBar()
    {
        if (transform.Find("canvas") != null)
        {
            return;
        }
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.01799598f, 0.1299774f);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(0.1490542f, 0.2400451f);
        gameObject.AddComponent<Rigidbody2D>();
        GameObject canvasObject = new GameObject("canvas");
        canvasObject.transform.SetParent(transform, false);
        canvasObject.transform.position = new Vector3(transform.position.x, transform.position.y+0.15f, transform.position.z);
        Canvas canvas = canvasObject.AddComponent<Canvas>();
        canvasObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.52f, 0.5f); 
        canvas.renderMode = RenderMode.WorldSpace;
        GameObject sliderObject = new GameObject("HealthBar");
        sliderObject.transform.SetParent(canvasObject.transform, false);
        slider = sliderObject.AddComponent<Slider>();
        RectTransform sliderRect = slider.GetComponent<RectTransform>();
        sliderRect.anchorMax = new Vector2(1, 1);
        sliderRect.anchorMin = new Vector2(0, 0);
        sliderRect.offsetMax = Vector2.zero;
        sliderRect.offsetMin = Vector2.zero;
        sliderRect.sizeDelta = new Vector2(0.5f, 0.6f);
        GameObject fillObject = new GameObject("Fill");
        fillObject.transform.SetParent(slider.transform, false);
        image = fillObject.AddComponent<Image>();
        image.color = Color.red;
        RectTransform imageRect = image.GetComponent<RectTransform>();
        imageRect.anchorMax = new Vector2(0, 1);
        imageRect.anchorMin = new Vector2(0, 1);
        imageRect.offsetMax = Vector2.zero;
        imageRect.offsetMin = Vector2.zero;
        sliderObject.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 1);
        sliderObject.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 1);
        sliderObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0.43f, 0.06000102f);
        slider.interactable = false;
        slider.transition = Selectable.Transition.None;
        slider.value = 1f;
        slider.fillRect = imageRect;
        slider.direction = Slider.Direction.LeftToRight;
    }

    protected void Awake()
    {
        setHealthBar();
        setSlider(slider);
    }

    // Start is called before the first frame update
    protected void Start()
    {

    }

    // Update is called once per frame
    protected void Update()
    {

    }
}
