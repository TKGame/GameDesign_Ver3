using UnityEngine;
using System.Collections;

public class CBlueDragonScripts : BaseEnemyScripts {
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        RunUpdateEnemy();
	}

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {

    }

    void OnTriggerStay2D(Collider2D collStay)
    {

    }

    void OnTriggerExit2D(Collider2D colExit)
    {

    }
    #endregion 
}
