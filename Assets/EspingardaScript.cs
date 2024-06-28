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
    // Start is called before the first frame update
    public MouseBehavior mouseAngle;
    public ThrowBehavior velocityBullet; 
    
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<Transform>();
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mouseAngle = this.AddComponent<MouseBehavior>();
        velocityBullet = this.AddComponent<ThrowBehavior>();
        getFireRate();

    }


    // Update is called once per frame
    void Update()
    {
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

    public void setScriptBullet()
    {
        GameObject obj = new GameObject();
        bullet = obj.AddComponent<bulletScript>();
    }

    public void spawnBullet()
    {
        float[] velocitys = velocityBullet.getSpeedRelativeToTheMouse(rotZ);
        // Debug.Log($"VelocidadeX: {velocitys[0] / 1.5f}"); 
        // Debug.Log($"VelocidadeY: {velocitys[1] / 1.5f}");
        bullet.setPositions(bulletSpawn.position);
        bullet.setRotation(0, 0, rotZ);
        bullet.settingUpTransformBullet();
        bullet.setDamageBullet(3f);
        bullet.setVelocity((velocitys[0] / 5f),(velocitys[1] / 5f));

    }

    private void getFireRate()
    {
        GameObject obj = new GameObject();
        fireRate = obj.AddComponent<fireRate>();
    }

}

