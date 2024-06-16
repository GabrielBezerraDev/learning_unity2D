using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspingardaScript : MonoBehaviour
{
    public bulletScript bullet;
    public fireRate fireRate;
    public GameObject obj;
    private Vector3 mouseVector;
    public float teste = 3f;
    public Camera mainCam;
    public float rotZ;
    public float rotCharacter;
    public Transform bulletSpawn;
    public Transform mainCharacter;
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<Transform>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        getFireRate();

    }

    // Update is called once per frame
    void Update()
    {
        mouseVector = mainCam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mouseVector - transform.position;
        Vector3 rotationCharacter = mouseVector - mainCharacter.transform.position;
        rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        rotCharacter = Mathf.Atan2(rotationCharacter.y, rotationCharacter.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        //Debug.Log(rotCharacter);
        if ((rotCharacter >= 90 || rotCharacter <= -90) && mainCharacter.transform.localScale.x > 0)
        {
            mainCharacter.transform.localScale = new Vector3(-1 * mainCharacter.transform.localScale.x, mainCharacter.transform.localScale.y, mainCharacter.transform.localScale.z);
            transform.localScale = new Vector3(-1 * transform.localScale.x, -1*transform.localScale.y, transform.localScale.z);

        }
        else if(mainCharacter.transform.localScale.x < 0 && (rotCharacter < 90 && rotCharacter > -90))
        {
            mainCharacter.transform.localScale = new Vector3(-1 * mainCharacter.transform.localScale.x, mainCharacter.transform.localScale.y, mainCharacter.transform.localScale.z);
            transform.localScale = new Vector3(-1 * transform.localScale.x, -1*transform.localScale.y, transform.localScale.z);

        }
        //Debug.Log(transform.rotation.z);
        if (Input.GetAxis("Mouse Y") != 0)
        {
            //double resultado = Math.Sqrt(Math.Pow(Input.GetAxis("Mouse X") - transform.position.x, 2) + Math.Pow(Input.GetAxis("Mouse Y") - transform.position.y, 2));
            //transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, (float) resultado);
            //Debug.Log(resultado);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if (fireRate.fireRatee(1f))
            {
                setScriptBullet();
                spawnBullet();
            }
            //Debug.Log($"eixo x: {transform.rotation.x}");
            //Debug.Log($"eixo y: {transform.rotation.y}");
            //Debug.Log($"Tangente: {Math.Atan2(transform.rotation.y, transform.rotation.x) * Mathf.Rad2Deg}");
        }
    }

    public void setScriptBullet()
    {
        GameObject obj = new GameObject();
        bullet = obj.AddComponent<bulletScript>();
    }

    public void spawnBullet()
    {
        //Debug.Log($"Eixo Y: {Mathf.Sin(rotation.y * Mathf.Deg2Rad)}");
        //Debug.Log($"Eixo X: {Mathf.Cos(rotation.x * Mathf.Deg2Rad)}");
        Debug.Log($"Eixo Y: {(rotation.normalized).y}");
        Debug.Log($"Eixo X: {(rotation.normalized).x}");
        bullet.setPositions(bulletSpawn.position);
        bullet.setRotation(0, 0, rotZ);
        bullet.settingUpTransformBullet();
        bullet.setVelocity( 8f, transform.rotation.z);
        //Debug.Log(rotZ);

    }

    private void getFireRate()
    {
        GameObject obj = new GameObject();
        fireRate = obj.AddComponent<fireRate>();
    }

}

