using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class moveCharacter : MonoBehaviour
{
    private Rigidbody2D characterRb2D;
    private float nextFireTime = 0f;
    private Collider2D playerCollision;
    private collisionGround ground;
    private Collider2D groundCollision;
    [SerializeField]
    public fireRate fireRate;
    public bulletScript testBullet;
    public int jumpValue = 3;
    public float horizontalVelocity = 3f;
    public int pixelBullet = 1;
    public HealthBehavior healthCharacter;
    public float runVelocity;
    public float maxVelocity;
    //public collisionGround test2;
    public int amountJump = 0;
    // Start is called before the first frame update
    void Start()
    {

        calculateVelocity();
        healthCharacter = GameObject.FindGameObjectWithTag("health").GetComponent<HealthBehavior>();
        characterRb2D = GetComponent<Rigidbody2D>();
        playerCollision = GetComponent<Collider2D>();
        groundCollision = GameObject.FindGameObjectWithTag("ground").GetComponent<Collider2D>();
        getFireRate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift) && horizontalVelocity < maxVelocity) {
                horizontalVelocity += runVelocity; 
            }else if (!Input.GetKey(KeyCode.LeftShift) && horizontalVelocity == maxVelocity)
            {
                horizontalVelocity -= runVelocity;
            }
            //Debug.Log(horizontalVelocity);
            characterRb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * horizontalVelocity, characterRb2D.velocity.y);
        }
        if ((Input.GetKeyDown(KeyCode.W) && amountJump < 2) || (Input.GetKeyDown(KeyCode.S) && !playerCollision.IsTouching(groundCollision))) {
            characterRb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * jumpValue);
            amountJump++;
        }
        //if (Input.GetKey(KeyCode.R))
        //{
        //    if (fireRate.fireRatee(2f))
        //    {
        //        setScriptBullet();
        //        spawnBullet();
        //    }
        //}
        if (Input.GetKey(KeyCode.T))
        {
            transform.position = new Vector3(-7.17f, -3.7f,0f);
            transform.rotation = Quaternion.identity;
            characterRb2D.velocity = new Vector3(0f,0f,0f);
        }
    }

    public void setScriptBullet()
    {
        GameObject obj = new GameObject();
        testBullet = obj.AddComponent<bulletScript>();
    }

    public void calculateVelocity()
    {
        runVelocity = (horizontalVelocity * 40) / 100;
        maxVelocity = horizontalVelocity + runVelocity;
    }

    public void spawnBullet()
    {
        //testBullet.setPositions(transform.position.x, transform.position.y, 1f);
        //testBullet.setVelocity(2f,transform.rotation.z);
        //testBullet.setRotation(0, 0, 0);
        //testBullet.settingUpTransformBullet();
        //testBullet.originBullet = "Player";
    }


    public void resetAmountJump()
    {
        amountJump = 0;
    }

    private void getFireRate()
    {
        GameObject obj = new GameObject();
        fireRate = obj.AddComponent<fireRate>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "jumpPowerUp")
        {
            horizontalVelocity = 9;
            calculateVelocity();
            jumpValue = 7;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.GetComponent<bulletScript>())
        {
            bulletScript bullet = collision.gameObject.GetComponent<bulletScript>();
            if (bullet.damage > 0)
            {
                this.healthCharacter.damageCharacter(bullet.damage);
                //Debug.Log("Levou Dano");
            }
        }

    }
}








