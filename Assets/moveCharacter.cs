using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class moveCharacter : MonoBehaviour, ProtocolCharacter
{
    private Rigidbody2D characterRb2D;
    private float nextFireTime = 0f;
    private Collider2D playerCollision;
    private collisionGround ground;
    private Collider2D groundCollision;
    [SerializeField]
    public fireRate fireRate;
    public bulletScript testBullet;
    public float jumpValue = 3;
    public float horizontalVelocity = 3f;
    public int pixelBullet = 1;
    public HealthBarScript healthCharacter;
    public float runVelocity;
    public Inventory inventory;
    public float maxVelocity;
    //public collisionGround test2;
    public int amountJump = 0;
    public GameObject gameObjectCollider;
    public ItemBehavior itemBehavior;
    // Start is called before the first frame update
    public MouseBehavior mouseAngle;

    private void Awake() {
        addComponentsInMainCharacter();
        setSliderHealth();
    }
    void Start()
    {
        getComponentsInMainCharacter();
        calculateVelocity();
        getGround();
    }

    // Update is called once per frame
    void Update()
    {
        setCharacterLookAngle();
        playerIsMove();
        playerIsJump();
        resetCharacterDefaultPosition();
        
    }

    public void addComponentsInMainCharacter(){
        mouseAngle = this.AddComponent<MouseBehavior>();
        healthCharacter = this.AddComponent<HealthBarScript>();
        inventory = this.AddComponent<Inventory>();
    }

    public void setSliderHealth(){
        healthCharacter.setSlider(gameObject.GetComponentInChildren<Canvas>().GetComponentInChildren<Slider>());
    }

    public void getComponentsInMainCharacter(){
        characterRb2D = GetComponent<Rigidbody2D>();
        playerCollision = GetComponent<Collider2D>();
    }

    public void getItemBehaviorInGameObjectCollider(){
        itemBehavior = gameObjectCollider.GetComponent<ItemBehavior>();
    }

    public void getGround(){
        groundCollision = GameObject.FindGameObjectWithTag("ground").GetComponent<Collider2D>();
    }

    public void getHealthCharacter(){
        healthCharacter = GameObject.FindGameObjectWithTag("health").GetComponent<HealthBarScript>();
    }

    public void playerIsRunner(){
        if (Input.GetKey(KeyCode.LeftShift) && horizontalVelocity < maxVelocity) {
            modifyRunHorizontalVelocity(runVelocity);
        }else if (!Input.GetKey(KeyCode.LeftShift) && horizontalVelocity == maxVelocity)
        {
            modifyRunHorizontalVelocity(-runVelocity);
        }
    }

    public void modifyRunHorizontalVelocity(float runVelocity){
            horizontalVelocity += runVelocity;
    }

    public void playerIsMove(){
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            playerIsRunner();
            setHorizontalVelocity();
        }
    }
    
    public void playerIsJump(){
        if ((Input.GetKeyDown(KeyCode.W) && amountJump < 2) || (Input.GetKeyDown(KeyCode.S) && !playerCollision.IsTouching(groundCollision))) {
            setVerticalVelocity();
            addJump();
        }
    }

    public void setVerticalVelocity(){
        characterRb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical") * jumpValue);
    }

    public void resetCharacterDefaultPosition(){
        if (Input.GetKey(KeyCode.T))
        {
            transform.position = new Vector3(-7.17f, -3.7f,0f);
            transform.rotation = Quaternion.identity;
            characterRb2D.velocity = new Vector3(0f,0f,0f);
        }
    }

    public void setHorizontalVelocity(){
        characterRb2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * horizontalVelocity, characterRb2D.velocity.y);
    }

    public void setCharacterLookAngle(){
        mouseAngle.setScale(transform, -1,1);   
    }

    public void setGameObjectCollider(GameObject gameObjectCollider){
        this.gameObjectCollider =  gameObjectCollider;
    }

    public void setObjectIntoInMainCharacter(){
        gameObjectCollider.transform.localPosition = itemBehavior.getPosition();
    }
    public void calculateVelocity()
    {
        runVelocity = (horizontalVelocity * 40) / 100;
        maxVelocity = horizontalVelocity + runVelocity;
    }

    public void resetAmountJump()
    {
        amountJump = 0;
    }

    public void addJump(){
        amountJump++;
    }

    public void increaseHorizontalVelocity(float velocity){
        horizontalVelocity = velocity;
    }

    public void increaseJumpValue(float velocity){
        jumpValue = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tagCollider = collision.gameObject.tag;
        if (tagCollider == "jumpPowerUp")
        {
            setGameObjectCollider(collision.gameObject);
            increaseHorizontalVelocity(9f);
            increaseJumpValue(7f);
            calculateVelocity();
            Destroy(gameObjectCollider);
        }
        if (tagCollider == "item")
        {
            setGameObjectCollider(collision.gameObject);
            Debug.Log(gameObjectCollider);
            getItemBehaviorInGameObjectCollider(); 
            inventory.setSlotPosition(itemBehavior.getSlotPosition());
            inventory.setSlotScale(itemBehavior.getSlotScale());
            inventory.setSlotRotation(itemBehavior.getSlotRotation());
            inventory.AddInventoryItem(gameObjectCollider);
            itemBehavior.setParent(transform);
            itemBehavior.isEquiped = true;
            setObjectIntoInMainCharacter();
            gameObjectCollider.SetActive(false);
        }
        

    }
}








