using UnityEngine;
using System.Collections;

public class AroundScipts : MonoBehaviour {
    public GameObject objTarget;
    
	// Use this for initialization
	void Start () {
        
	}
	
	void OnTriggerEnter2D(Collider2D colEnter)
    {
        if(colEnter.gameObject.tag == "Player")
        {
            //objTarget.GetComponent<BlueSnailScripts>().inAroundOfPlayer = true;
        }
    }
    void OnTriggerExit2D(Collider2D colExit)
    {
        if(colExit.tag == "Player")
        {
            objTarget.GetComponent<BlueSnailScripts>().inAroundOfPlayer = false;   
        }
    }
}
