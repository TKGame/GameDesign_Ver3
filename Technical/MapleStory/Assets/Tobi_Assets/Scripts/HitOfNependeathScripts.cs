﻿using UnityEngine;
using System.Collections;

public class HitOfNependeathScripts : MonoBehaviour {

    public float speedMoveX;
    Animator _anim;

    public GameObject objNependeath;
    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Hit";
        _anim = gameObject.GetComponent<Animator>();
        objNependeath = transform.parent.gameObject;
        
    }

    float _timeDelay = 0.0f;
    void Update()
    {
        float speedCurrent = objNependeath.GetComponent<NependeathScripts>().speed;

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedCurrent * speedMoveX, 0);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.gameObject.tag == "Rank")
        {
            gameObject.SetActive(false);
        }
    }
}
