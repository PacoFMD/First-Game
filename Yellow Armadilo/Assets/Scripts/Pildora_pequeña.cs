using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pildora_pequeña : MonoBehaviour {

    GameObject armadillo;
    public float TamX = .5f, TamY = .5f, TamZ = .5f;

    // Use this for initialization
    void Start () {
        armadillo = GameObject.Find("Player");
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            armadillo.gameObject.transform.localScale = new Vector3(TamX, TamY, TamZ);

            Destroy(this.gameObject);
        }
    }
}
