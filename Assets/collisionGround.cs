using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionGround : MonoBehaviour
{

    public moveCharacter mainCharacter;
    public bool isCollisionWithGround = true;
    public string teste = "Pegou";
    // Start is called before the first frame update
    void Start()
    {
        mainCharacter = GameObject.FindGameObjectWithTag("mainCharacter").GetComponent<moveCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tocou no chão");
        mainCharacter.resetAmountJump();
    }
    }

