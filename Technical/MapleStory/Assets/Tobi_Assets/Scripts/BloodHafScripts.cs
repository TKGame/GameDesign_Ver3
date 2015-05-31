using UnityEngine;
using System.Collections;

public class BloodHafScripts : BaseEnemyScripts {

    float timeDelay = 0.0f;

    public Transform PositionCreateHit;

    public GameObject hit1;

    public GameObject hit2;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        //playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
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


    [ContextMenu("create")]
    public void CreateHit()
    {
        Instantiate(hit1,PositionCreateHit.position,Quaternion.identity);
        Instantiate(hit2, PositionCreateHit.position, Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D colStay)
    {
        if(colStay.tag == "Around")
        {
            attack = true;
            move = false;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if(colExit.tag == "Around")
        {
            attack = false;
            move = true;
        }
    }
}
