using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public int vel, Xdir;
    SpriteRenderer sr;
    public GameObject spawnpoint;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Xdir, 0) * vel;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = spawnpoint.transform.position;
        }

        Flip();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    void Flip()
    {
        if (Xdir > 0)
        {
            Xdir = -1;
            sr.flipX = false;
        }
        else
        {
            Xdir = 1;
            sr.flipX = true;
        }
    }

}
