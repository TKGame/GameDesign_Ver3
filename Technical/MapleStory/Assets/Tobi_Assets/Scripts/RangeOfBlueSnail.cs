using UnityEngine;
using System.Collections;

public class RangeOfBlueSnail : MonoBehaviour {

	public GameObject objBlueSnail;
	// Use this for initialization
	void Start () {
        //objStone = GameObject.FindGameObjectWithTag("Stone").gameObject;
        objBlueSnail = transform.parent.gameObject;
	}


    void OnTriggerStay2D(Collider2D colEnter)
    {
        if(colEnter.tag == "Player")
        {
            objBlueSnail.GetComponent<BlueSnailScripts>().inAroundOfPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag == "Player")
        {
            objBlueSnail.GetComponent<BlueSnailScripts>().inAroundOfPlayer = false;
        }
    }
	
}
