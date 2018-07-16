using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletTime = 0.1f;
    void Start()
    {
        //Debug.Log("11111");
        Destroy(this.gameObject, BulletTime);
    }
   
}
 