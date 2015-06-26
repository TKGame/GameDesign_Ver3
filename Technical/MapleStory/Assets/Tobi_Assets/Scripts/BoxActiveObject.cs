using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoxActiveObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    List<GameObject> listObj;
    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag != CTag.tagGound2 || col.tag != CTag.tagPlayer)
        {
            Debug.Log("ok");
            col.gameObject.SetActive(true);
        }
    }
}
