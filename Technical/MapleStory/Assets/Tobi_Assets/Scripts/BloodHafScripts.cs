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
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null)
        {
            RunUpdateEnemy(transform);
        }
	}


    [ContextMenu("create")]
    public void CreateHit()
    {
        Instantiate(hit1,PositionCreateHit.position,Quaternion.identity);
        Instantiate(hit2, PositionCreateHit.position, Quaternion.identity);
    }

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        onTriggerEnter2D_Shoot(colEnter);
    }
    void OnTriggerStay2D(Collider2D colStay)
    {
        onTriggerStay2D_Shoot(colStay);
    }
    void OnTriggerExit2D(Collider2D colExit)
    {
        onTriggerExit2D_Shoot(colExit);
    }
}
