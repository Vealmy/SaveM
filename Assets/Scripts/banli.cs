using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banli : MonoBehaviour {

    public float BSpeed = 0.5f;
    public bool IsFaceR = false;
    public GameObject Bgameobject;
   
    public void BanliMove()
    {
        if (IsFaceR){
            transform.Translate(Vector3.right * BSpeed * Time.deltaTime);
          //  Debug.Log("rrr");
        }
        else{
            transform.Translate(Vector3.left * BSpeed * Time.deltaTime);
            //Debug.Log("lll");
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "R"){
            IsFaceR = false;
        }
        if (other.gameObject.tag == "L"){
            IsFaceR = true;
        }
    
   
        
    }
   
    // Update is called once per frame
    void Update () {
        BanliMove();
    }
}
