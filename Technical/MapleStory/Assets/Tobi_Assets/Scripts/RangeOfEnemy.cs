using UnityEngine;
using System.Collections;

public class RangeOfEnemy : MonoBehaviour {
    public GameObject objStone;
	// Use this for initialization
	void Start () {
        //objStone = GameObject.FindGameObjectWithTag("Stone").gameObject;
        objStone = transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D colEnter)
    {
        if(colEnter.tag == "Player")
        {
            objStone.GetComponent<StoneScripts>().inAroundOfPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag == "Player")
        {
            objStone.GetComponent<StoneScripts>().inAroundOfPlayer = false;
        }
    }
}
