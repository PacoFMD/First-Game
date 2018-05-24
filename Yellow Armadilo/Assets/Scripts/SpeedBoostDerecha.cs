using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostDerecha : MonoBehaviour {

    public float vel = 6.0f;
    Rigidbody2D rig;
    // Use this for initialization
    void Start()
    {
        rig = GameObject.Find("Player").GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            rig.AddForce(-transform.up * vel, ForceMode2D.Impulse);

        }
    }
}
