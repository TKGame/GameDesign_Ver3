﻿using UnityEngine;
using System.Collections;

public class BlueMushroomScripts : BaseEnemyScripts {
	// Use this for initialization
    public float jumbForce = 400.0f;
    // biến xác định nhảy
    bool isJumb = false;
    // xác định đứng trên mặt đất
    public bool grounded;
    //điểm xác định đứng trên mặt đất
    public Transform groundCheck;

    float _timeDelay = 0;
	void Start () {
        InitStart();
        isMove = true;
        groundCheck = transform.Find("groundCheck");

        rigid = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
           // grounded = Physics2D.Linecast(groundCheck.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
            if ((_timeDelay += Time.deltaTime) >= 3 && isJumb)
            {
                rigid.AddForce(new Vector2(0, jumbForce));
                _timeDelay = 0;
            }
            if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
            {
                Flip();
            }
            if(isMove)
            {
                Move(speed);
            }
        }
        // update trạng thái die
        Die();
    }

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Player")
        {
            isMove = false;
            isJumb = true;
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
        }
        if(colEnter.tag == "Ground")
        {
            
            grounded = true;
            Debug.Log(grounded);
        }
        if (colEnter.tag == "GroundTop" && grounded)
        {
            Debug.Log("abc");
            int rand = Random.Range(0, 2);
            if (rand == 0 && rigid != null)
            {
                rigid.AddForce(new Vector2(10, 650));
            }
            else 
                Flip();
        }
    }
    void OnTriggerExit2D(Collider2D colExit)
    {
        isMove = true;
        isJumb = false;
        if(colExit.tag == "Ground")
        {
            grounded = false;
            Debug.Log(grounded);
        }
    }
}
