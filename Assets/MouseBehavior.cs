using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{

    private Vector3 mouseVector;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkMouseAngle(Transform objectTransform, int scaleX, int scaleY){
        mouseVector = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mouseVector - objectTransform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        objectTransform.rotation = Quaternion.Euler(0, 0, rotZ);
        if ((rotZ >= 90 || rotZ <= -90) && objectTransform.transform.localScale.x > 0)
        {
            objectTransform.transform.localScale = new Vector3(scaleX * objectTransform.transform.localScale.x,  scaleY * objectTransform.transform.localScale.y, objectTransform.transform.localScale.z);
        }
        else if(objectTransform.transform.localScale.x < 0 && (rotZ < 90 && rotZ > -90))
        {
            objectTransform.transform.localScale = new Vector3(scaleX * objectTransform.transform.localScale.x, scaleY * objectTransform.transform.localScale.y, objectTransform.transform.localScale.z);
        }
    }
}

//Character scale:
//scaleX: -1
//scaleY: 1

//Espingarda scale:
//scaleX: -1
//scaleY: -1
