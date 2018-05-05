using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolinScript : MonoBehaviour {
    bool onTop;
    GameObject bouncer;
    Animator anim;
    public Vector2 velocity;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (onTop)
        {
            anim.SetBool("isStepped", true);
            bouncer = other.gameObject;
        }
    }

    void OnTriggerEnter2D()
    {
        onTop = true;
    }
    void OnTriggerExit2D()
    {
        onTop = false;
        anim.SetBool("isStepped", false);
    }

    void OnTriggerStay2D()
    {
        onTop = true;
    }

    void Jump()
    {
        bouncer.GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
