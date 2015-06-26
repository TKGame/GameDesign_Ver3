using UnityEngine;
using System.Collections;

public class TableTalking : MonoBehaviour {

    public GameObject objPlayer;

    public GameObject tableTalking;
	// Use this for initialization
	void Start () {
        objPlayer = GameObject.FindGameObjectWithTag(CTag.tagPlayer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(objPlayer != null && col.tag ==  CTag.tagPlayer)
        {
            tableTalking.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
