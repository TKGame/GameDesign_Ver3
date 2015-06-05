using UnityEngine;
using System.Collections;

public class ZombieScripts : BaseEnemyScripts {

    float timeDelay = 0.0f;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        RunUpdateEnemy(transform);
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
            //Debug.Log("attack");
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
