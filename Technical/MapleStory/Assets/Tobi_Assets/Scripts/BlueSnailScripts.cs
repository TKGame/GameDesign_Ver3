using UnityEngine;
using System.Collections;

public class BlueSnailScripts : BaseEnemyScripts {
    void Start()
    {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        gameObject.tag = "Hit";
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
            RunUpdateEnemy(transform);
        }
    }

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
}
