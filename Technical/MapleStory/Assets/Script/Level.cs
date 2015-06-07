using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {


    public GameObject canh1;
    public GameObject canh2;
    public PlayerController player;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            UpLevel();
        }
    }
    void UpLevel()
    {
        if (player != null)
        {
            player.transform.position = new Vector3(-6, 0);
        }
        canh2.SetActive(true);
        canh1.SetActive(false);
    }
}
