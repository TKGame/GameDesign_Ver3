using UnityEngine;
using System.Collections;

public class StoneScripts : BaseEnemyScripts {

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
        onTriggerEnter2D(colEnter);
    }

    void OnTriggerStay2D(Collider2D collStay)
    {
        onTriggerStay2D(collStay);
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        onTriggerExit2D(colExit);
    }

    #endregion 
}
