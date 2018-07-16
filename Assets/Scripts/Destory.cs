using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destory : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Banli")
        {
            Destroy(GameObject.FindGameObjectWithTag("Banli"));
            Debug.Log("banli");
           // IsFaceR = false;
        }
        
    }

// Update is called once per frame
void Update () {
		
	}
}
