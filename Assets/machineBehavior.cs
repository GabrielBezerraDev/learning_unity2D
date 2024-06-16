using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machineBehavior : MonoBehaviour
{
    GameObject obj;
    bulletScript bullet;
    public GameObject spawnBulletMachineGun;
    fireRate fireRate;
    // Start is called before the first frame update
    void Start()
    {
        //setBulletScript();
        getFireRate();
    }

    // Update is called once per frame
    void Update()
    {
        createBullet();
    }

    private void getFireRate()
    {
        GameObject obj = new GameObject();
        fireRate = obj.AddComponent<fireRate>();
    }

    public void setScriptBullet()
    {
        GameObject obj = new GameObject();
        bullet = obj.AddComponent<bulletScript>();
    }

    public void createBullet()
    {

        // if (fireRate.fireRatee(3f))
        // {
        //     setScriptBullet();
        //     bullet.setPositions(spawnBulletMachineGun.transform.position);
        //     bullet.setVelocity(-6f, transform.rotation.z);
        //     bullet.setGravity();
        //     bullet.setDamageBullet(20f);
        //     bullet.setRotation(0,180,0);
        //     bullet.settingUpTransformBullet();
        // }
    }
}