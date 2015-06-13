using UnityEngine;
using System.Collections;

public class RangeOfEnemy : MonoBehaviour {
    //public BaseEnemyScripts baseEnemyScripts;
    public GameObject obj;
	// Use this for initialization
	void Start () {
        obj = transform.parent.gameObject;
        //objStone = GameObject.FindGameObjectWithTag("Stone").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D colEnter)
    {
        if(colEnter.tag == "Player")
        {
            //objStone.GetComponent<StoneScripts>().inAroundOfPlayer = true;
            //baseEnemyScripts.GetComponent<BaseEnemyScripts>
            obj.GetComponent<BaseEnemyScripts>().inAroundOfPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag == "Player")
        {
            obj.GetComponent<BaseEnemyScripts>().inAroundOfPlayer = false;
        }
    }
}
