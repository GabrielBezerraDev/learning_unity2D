using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class factoryBullet : MonoBehaviour
{
    public bulletScript createBullet()
    {
        GameObject obj = new GameObject();
        return obj.AddComponent<bulletScript>();
    }
}
