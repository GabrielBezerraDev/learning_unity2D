using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class ObjectPropertys : MonoBehaviour
{
    public float damage;
    public float forceX, forceY = 300f;
    public Vector3 position;
    private float rotationX;
    private float rotationY;
    private float rotationZ;
    private float bulletX;
    private float bulletY;
    private float velocityX;
    private float velocityY;
    private Camera mainCamera;
    private Rigidbody2D rbBullet2D;
    private SpriteRenderer spriteBullet;
    private BoxCollider2D boxColliderBullet;
    private GameObject gameObjectConfiguration;



    private void Update()
    {
        if(gameObjectConfiguration){
            gameObjectConfiguration.transform.right = GetComponent<Rigidbody2D>().velocity;
            destroyObject();
        }
    }

    private void Awake()
    {
    }

    private void Start()
    {
        getMainCamera();
    }

    public void setGameObject(GameObject gameObject){
        gameObjectConfiguration = gameObject;
    }

    private void destroyObject()
    {
        if (checkObjectIsOutSideInCamera()) Destroy(gameObjectConfiguration);
    }

    private void getMainCamera()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }


    public void settingUpRigidbody2DBullet()
    {
        rbBullet2D = gameObjectConfiguration.GetComponent<Rigidbody2D>();
        rbBullet2D.velocity = new Vector3(velocityX, velocityY, 0);
    }



    public void setGravity()
    {
        rbBullet2D.gravityScale = 0.1f;
    }

    public void settingUpTransformBullet()
    {
        gameObjectConfiguration.transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
        // gameObjectConfiguration.transform.localScale = new Vector3(0.1191056f, 0.09714954f, 1);
        gameObjectConfiguration.transform.localScale = new Vector3(
           gameObjectConfiguration.transform.localScale.x * 1.5f, gameObjectConfiguration.transform.localScale.y * 1.5f, gameObjectConfiguration.transform.localScale.z * 1.5f
        );
        gameObjectConfiguration.transform.position = position;
    }

    public bool checkObjectIsOutSideInCamera()
    {
        Vector3 viewPort = mainCamera.WorldToViewportPoint(gameObjectConfiguration.transform.position);
        return viewPort.x < 0 || viewPort.x > 1 || viewPort.y < 0 || viewPort.y > 1;
    }

    public void setPositions(Vector3 position)
    {
        this.position = position;
    }



    public void setRotation(float x, float y, float z)
    {
        rotationX = x;
        rotationY = y;
        rotationZ = z;
    }

    public void setVelocity(float velocityX, float velocityY)
    {
        Debug.Log("Setando velocidades");
        this.velocityX = velocityX;
        this.velocityY = velocityY;
        settingUpRigidbody2DBullet();
    }

    public void setDamageBullet(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObjectConfiguration);
    }

}

