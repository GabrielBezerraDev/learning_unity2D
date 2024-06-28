using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehavior : MonoBehaviour
{
    public Vector3 rotation;
    public static float rotZ;
    public GameObject mainCharacter;
    public Camera mainCam;
    private Vector3 mouseVector;
    // Start is called before the first frame update
    
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter");
        setMouseAngle();
    }

    // Update is called once per frame
    void Update()
    {
        setMouseAngle();
        Debug.Log(rotZ);
    }

    public void setMouseAngle(){
        mouseVector = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mouseVector - mainCharacter.transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
    }

    public void setAngleObject(Transform objectTransform){
        objectTransform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    public void setScale(Transform objectTransform, int scaleX, int scaleY){
        if ((rotZ >= 90 || rotZ <= -90) && objectTransform.transform.localScale.x > 0)
        {
            objectTransform.transform.localScale = new Vector3(scaleX * objectTransform.transform.localScale.x, scaleY * objectTransform.transform.localScale.y, objectTransform.transform.localScale.z);
        }
        else if (objectTransform.transform.localScale.x < 0 && (rotZ < 90 && rotZ > -90))
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
