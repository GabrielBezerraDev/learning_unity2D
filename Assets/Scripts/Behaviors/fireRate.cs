using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class fireRate : MonoBehaviour
{

    private float nextFireTime;
    private bool timeOut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool fireRatee(float fireRate)
    {
        timeOut = false;
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            timeOut = true;
        }
        return timeOut;
    }
}
