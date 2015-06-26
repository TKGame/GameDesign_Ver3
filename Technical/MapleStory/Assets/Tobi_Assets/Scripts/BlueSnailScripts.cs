﻿using UnityEngine;
using System.Collections;

public class BlueSnailScripts : BaseEnemyScripts {

    //public bool inAroundOfPlayer = false;
    bool _facingRight = true;
    public bool isAttack = false;

    float _timeDelay = 0;
    public float dis_TimeDelay = 3.0f;
    float _startSpeed;

    public Transform frontCheck;
    Collider2D[] listCol2D;
    void Start()
    {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;
        
        _startSpeed = speed;
        frontCheck = transform.Find("FrontCheck");
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
            Die();
            if (isAttack == false)
            {
                if ((_timeDelay += Time.deltaTime) >= dis_TimeDelay && inAroundOfPlayer == false)
                {
                    isMove = !isMove;
                    _timeDelay = 0;
                }
                UpdateStatusMove();
            }
            _animator.SetBool("isAttack", isAttack);
        }
        if (frontCheck != null)
        {
            listCol2D = Physics2D.OverlapPointAll(frontCheck.position);
            foreach (Collider2D col in listCol2D)
            {
                if (col.tag == CTag.tagGound2)
                {
                    Flip();
                }
            }
        }
    }
    public void UpdateStatusMove()
    {
        if (inAroundOfPlayer == false)                    // nếu nằm ngoài vùng bao
        {
            if(isMove)
            {
                Move(speed);
            }
            if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
            {
                Flip();
            }
        }
        else                                            // nếu nằm trong vùng bao
        {
            if (playerObj.transform.position.x < transform.position.x && speed > 0 || playerObj.transform.position.x > transform.position.x && speed < 0)
            {
                if (_facingRight)
                {
                    _facingRight = !_facingRight;
                    Flip();
                }
                else
                    _facingRight = !_facingRight;
            }

            Move(speed);

            if (transform.position.x > startPosition.x + distanceMove || transform.position.x < startPosition.x - distanceMove)
            {
                startPosition = transform.position;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == CTag.tagPlayer)
        {
            isAttack = true;
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
            //if(transform.localScale.x > 0)
            //{
            //    rigid.AddForce(new Vector2(200, 0));
            //}else
            //{
            //    rigid.AddForce(new Vector2(-200, 0));
            //}
        }

        if(colEnter.tag == CTag.tagGound2)
        {
            Flip();
        }
        if(colEnter.tag == CTag.tagHitOfPlayer)
        {
            _animator.SetBool("isHit",true);
            speed = 0;
        }
    }

    public void SetFrameFinalHit()
    {
        _animator.SetBool("isHit", false);
        speed = _startSpeed;
        
    }
    void OnTriggerStay2D(Collider2D collStay)
    {
        if (collStay.tag == "Player")
        {
            isAttack = true;
            //rigid.AddForce(new Vector2(2,0));
        }
        //if(collStay.tag == CTag.tagGound2)
        //{
        //    Flip();
        //}
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        isAttack = false;
    }
}
