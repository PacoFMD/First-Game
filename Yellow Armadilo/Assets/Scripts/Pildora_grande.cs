using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pildora_grande : MonoBehaviour {

    GameObject armadillo;
    public float TamX= 1.5f,TamY = 1.5f, TamZ= 1.5f;

    // Use this for initialization
    void Start()
    {
        armadillo = GameObject.Find("Player");


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            armadillo.gameObject.transform.localScale = new Vector3(TamX, TamY, TamZ);

            Destroy(this.gameObject);
        }
    }
}
