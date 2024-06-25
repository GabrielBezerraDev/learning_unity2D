using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class EspingardaScript : MonoBehaviour
{
    public bulletScript bullet;
    public fireRate fireRate;
    public GameObject obj;
    public float teste = 3f;
    public Camera mainCam;
    public float rotZ;
    public float rotCharacter;
    public Transform bulletSpawn;
    public Transform mainCharacter;
    public Vector3 rotation;
    // Start is called before the first frame update
    public MouseBehavior mouseAngle;
    
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<Transform>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        getFireRate();

    }


    // Update is called once per frame
    void Update()
    {
        mouseAngle = gameobject.AddComponent<MouseBehavior>();
        mouseAngle.checkMouseAngle(transform, -1,-1);
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
        }
    }

    public void setScriptBullet()
    {
        GameObject obj = new GameObject();
        bullet = obj.AddComponent<bulletScript>();
    }

    public void spawnBullet()
    {
        float velocityY;
        float velocityX;
        if (rotZ > 0)
        {
            if (rotZ > 0 && rotZ < 90)
            {
                velocityY = rotZ;
                velocityX = 90 - rotZ;
            }
            else
            {
                velocityX = rotZ - 90;
                velocityY = 90 - velocityX;
                velocityX *= -1f;
            }
        }
        else
        {
            if (rotZ < 0 && rotZ > -90)
            {
                velocityY = rotZ;
                velocityX = 90 - (-rotZ);
            }
            else
            {
                velocityX = (-rotZ) - 90;
                velocityY = 90 - velocityX;
                velocityX *= -1f;
                velocityY *= -1f;
            }
        }
        Debug.Log($"VelocidadeX: {velocityX / 1.5f}"); 
        Debug.Log($"VelocidadeY: {velocityY / 1.5f}");
        bullet.setPositions(bulletSpawn.position);
        bullet.setRotation(0, 0, rotZ);
        bullet.settingUpTransformBullet();
        bullet.setDamageBullet(3f);
        bullet.setVelocity((velocityX/5f),(velocityY/5f));

    }

    private void getFireRate()
    {
        GameObject obj = new GameObject();
        fireRate = obj.AddComponent<fireRate>();
    }

}

