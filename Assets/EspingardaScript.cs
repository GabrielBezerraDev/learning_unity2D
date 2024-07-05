using Unity.VisualScripting;
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

    public MouseBehavior mouseAngle;
    public ThrowBehavior velocityBullet; 

    public bool isEquiped = false;

    public ItemBehavior itemBehavior;
    private Vector3 slotPosition = new Vector3(5.209733e-05f,7.8f,0);
    private Vector3 slotScale = new Vector3(1.714941f,1.714941f,0);
    private Vector3 slotRotation = new Vector3(0,0,36.25f);

    private Vector3 positionInMainCharacter = new Vector3(-0.03f,-0.038f,0);
    
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<Transform>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mouseAngle = this.AddComponent<MouseBehavior>();
        itemBehavior = this.AddComponent<ItemBehavior>();
        velocityBullet = this.AddComponent<ThrowBehavior>();
        itemBehavior.setPosition(positionInMainCharacter);
        itemBehavior.isEquiped = isEquiped;
        getFireRate();
        setSlotConfiguration();

    }


    // Update is called once per frame
    void Update()
    {
        if(!itemBehavior.isEquiped) return;
        mouseAngle.setScale(transform, -1,-1);
        mouseAngle.setAngleObject(transform);
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

    public void setSlotConfiguration(){
        itemBehavior.setSlotPosition(slotPosition);
        itemBehavior.setSlotRotation(slotRotation);
        itemBehavior.setSlotScale(slotScale);
    }
    public void setScriptBullet()
    {
        GameObject obj = new GameObject();
        bullet = obj.AddComponent<bulletScript>();
    }

    public void spawnBullet()
    {
        float[] velocitys = velocityBullet.getSpeedRelativeToTheMouse(rotZ);
        bullet.setPositions(bulletSpawn.position);
        bullet.setRotation(0, 0, rotZ);
        bullet.settingUpTransformBullet();
        bullet.setDamageBullet(50f);
        bullet.setVelocity((velocitys[0] / 3f),(velocitys[1] / 3f));

    }

    private void getFireRate()
    {
        GameObject obj = new GameObject();
        fireRate = obj.AddComponent<fireRate>();
    }

}

