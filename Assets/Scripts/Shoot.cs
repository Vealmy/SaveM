using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public float BulletVer = 0.5f;
    public GameObject Bullet;
    public Transform Gun;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.J))
        {
            BulletVer -= Time.deltaTime;
            if (Mathf.Abs(BulletVer) < 0.05f)
            {
                GameObject obj = Instantiate(Bullet, Gun) as GameObject;
                //obj.transform.SetParent(transform);
                BulletVer = 0.5f;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            GameObject obj = Instantiate(Bullet, Gun) as GameObject;
            //sobj.transform.SetParent(transform);


            // Debug.Log("j");

        }
    }
//    public float MoveSpeed = 1f;
//    //public GameObject bullet;
//    public float V;
//    public GameObject bullet;
//    // Use this for initialization

//    public void Fire()
//    {
       
//        GameObject.Instantiate(bullet, transform.position, Quaternion.identity);
//    }
    
//    // Update is called once per frame
//    public void openFire()
//{
//    if (Input.GetKey(KeyCode.J)) {
//        InvokeRepeating("Fire", 1, MoveSpeed); }
//    }
}
