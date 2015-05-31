using UnityEngine;
using System.Collections;

public class DrextonScripts : BaseEnemyScripts {

    float timeDelay = 0.0f;

    public Transform posiotionCreateHit;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        //Flip();
    }

    // Update is called once per frame
    void Update()
    {
        distanceEnemyToPlayer = playerObj.transform.position.x - this.transform.position.x;
        if (playerObj != null)
        {
            UpdateStatusOfEnemy();
            if ((timeDelay += Time.deltaTime) >= 3 && inAroundOfPlayer == false)
            {
                move = !move;
                timeDelay = 0;
            }
            Die();
        }
    }

    public void CreateHit()
    {
        Instantiate(bullet, posiotionCreateHit.position,Quaternion.identity);
    }

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Around")
        {
            // trong vung bao cua player
            //inAroundOfPlayer = false;
            //move = false;
            //attack = true;
        }
    }

    void OnTriggerStay2D(Collider2D collStay)
    {
        if(collStay.gameObject.tag == "Around")
        {
            inAroundOfPlayer = false;
            attack = true;
            move = false;
        }
        if (collStay.gameObject.tag == "Player")
        {
            //move = true;
            //attack = false;
            //inAroundOfPlayer = false;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag == "Around")
        {
            inAroundOfPlayer = false;
            attack = false;
            move = true;
        }

        if (colExit.gameObject.tag == "Player")
        {
            //attack = false;
            //move = true;
            //inAroundOfPlayer = true;
        }
    }
    #endregion
}
