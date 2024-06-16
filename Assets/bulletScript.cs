using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;

public class bulletScript : MonoBehaviour
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
    private Camera mainCamera;
    private Rigidbody2D rbBullet2D;
    private SpriteRenderer spriteBullet;
    private BoxCollider2D boxColliderBullet;



    private void Update()
    {
        transform.right = this.GetComponent<Rigidbody2D>().velocity;
        destroyObject();
    }

    private void Awake()
    {
        setComponentsBullet();
    }

    private void Start()
    {
        getMainCamera();
        settingUpSpriteRendererBullet();
        settingUpBoxCollider2DBullet();
        //GetComponent<Rigidbody2D>().AddForce(new Vector3(-1200f, 0f));
    }

    private void destroyObject()
    {
        if (checkObjectIsOutSideInCamera()) Destroy(gameObject);
    }

    private void getMainCamera()
    {
        this.mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void setComponentsBullet()
    {
        rbBullet2D = this.AddComponent<Rigidbody2D>();
        spriteBullet = this.AddComponent<SpriteRenderer>();
        boxColliderBullet = this.AddComponent<BoxCollider2D>();
    }

    private void settingUpSpriteRendererBullet()
    {
        spriteBullet.sprite = Resources.Load<Sprite>("bullet");
    }

    public void settingUpRigidbody2DBullet()
    {
        //Debug.Log($"Essa é a força do eixoY: {10000f * transform.rotation.z}");
        //this.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.velocityX * this.rotationGun * 230f, this.velocityX * (this.rotationGun*200f)));
        rbBullet2D.velocity = transform.right * this.velocityX;

        //this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
    }

    private void settingUpBoxCollider2DBullet()
    {
        boxColliderBullet.size = new Vector2(1.615206f, 0.8471732f);
    }

    public void setGravity()
    {
        rbBullet2D.gravityScale = 0.1f;
    }

    public void settingUpTransformBullet()
    {
        //Quaternion quaternion = new Quaternion();
        //quaternion.x = this.rotationX;
        //quaternion.y = this.rotationY;
        //quaternion.z = this.rotationZ;
        this.transform.rotation = Quaternion.Euler(this.rotationX, rotationY, rotationZ);
        this.transform.localScale = new Vector3(0.1191056f, 0.09714954f, 1);
        this.transform.position = this.position;
    }

    public bool checkObjectIsOutSideInCamera()
    {
        Vector3 viewPort = mainCamera.WorldToViewportPoint(this.transform.position);
        return viewPort.x < 0 || viewPort.x > 1 || viewPort.y < 0 || viewPort.y > 1;
    }

    //public void setPositions(float x, float y, float farAway)
    //{
    //    this.bulletX = x;
    //    this.bulletY = y;
    //    this.farAway = farAway;
    //}

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

    public void setVelocity(float velocityX, float rotationGun)
    {
        this.velocityX = velocityX;
        //this.rotationGun = rotationGun;
        this.settingUpRigidbody2DBullet();
    }

    public void setDamageBullet(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    public void testClass()
    {
        //Debug.Log("Working");
    }

}
