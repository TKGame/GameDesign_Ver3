﻿using UnityEngine;
using System.Collections;

public class StoneScripts : BaseEnemyScripts {
    float timeDelay = 0.0f;

    public Transform positionCreateHit;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        //playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        distanceEnemyToPlayer = playerObj.transform.position.x - this.transform.position.x;
        if (playerObj != null)
        {
            UpdateStatusOfEnemy();
            if ((timeDelay += Time.deltaTime) >= distanceTimeDelayOfEnemy && inAroundOfPlayer == false)
            {
                move = !move;
                timeDelay = 0;
            }
            Die();
        }
	}

    public void Createhit()
    {
        Instantiate(bullet, positionCreateHit.position, Quaternion.identity);
    }



    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Around")
        {
            // trong vung bao cua player
            inAroundOfPlayer = true;
            move = true;
        }
    }

    void OnTriggerStay2D(Collider2D collStay)
    {
        if (collStay.gameObject.tag == "Player")
        {
            move = false;
            attack = true;
            inAroundOfPlayer = false;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag == "Around")
        {
            inAroundOfPlayer = false;
        }

        if (colExit.gameObject.tag == "Player")
        {
            attack = false;
            move = true;
            inAroundOfPlayer = true;
        }
    }
    #endregion 
}
