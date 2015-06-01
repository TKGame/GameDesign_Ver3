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
        RunUpdateEnemy(transform);
    }

    public void CreateHit()
    {
        Instantiate(bullet, posiotionCreateHit.position,Quaternion.identity);
    }

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        //if (colEnter.tag == "Around")
        //{
        //    // trong vung bao cua player
        //    inAroundOfPlayer = false;
        //    move = false;
        //    attack = true;
        //}
    }

    void OnTriggerStay2D(Collider2D collStay)
    {
        onTriggerStay2D_Shoot(collStay, "Around");
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        onTriggerExit2D(colExit, "Around");
    }
    #endregion
}
