using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
public class BaseHitScripts:MonoBehaviour
{
    // van toc di chuyen cua hit
    public float speedMoveX;
    public float speedMoveY;

    Animator _anim;

    public GameObject ObjectTarget;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        // xac dinh huong bay
        float speedCurrent = ObjectTarget.GetComponent<DrextonScripts>().speed;

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedCurrent * speedMoveY, speedMoveY);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            speedMoveY = 0;
            _anim.SetTrigger("collision");
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}

