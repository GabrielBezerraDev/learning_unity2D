using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class herobrine : MonoBehaviour
{
    public float velocity = -0.20f;
    public float timeWalking = 10f;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        //time = Time.time;
        //this.AddComponent<Rigidbody@>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeWalking)
        {
            velocity = 0f;
            timeWalking = Time.time + 10;
        }
        //else if(Time.time < timeWalking)
        //{
        //    velocity = -1f;
        //    Debug.Log("andando");
        //}
        //this.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity, 0f);
    }
}
