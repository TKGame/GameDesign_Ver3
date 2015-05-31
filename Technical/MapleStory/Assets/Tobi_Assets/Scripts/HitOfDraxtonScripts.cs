﻿using UnityEngine;
using System.Collections;

public class HitOfDraxtonScripts : MonoBehaviour {

    // van toc di chuyen cua hit
    public float speedMove;

    Animator _anim;

    public GameObject draxtonObj;

	// Use this for initialization
	void Start () {
        _anim = gameObject.GetComponent<Animator>();

        float speedCurrent = draxtonObj.GetComponent<DrextonScripts>().speed;

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedCurrent*speedMove,0);
	}
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            speedMove = 0;
            _anim.SetTrigger("collision");
        }
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
