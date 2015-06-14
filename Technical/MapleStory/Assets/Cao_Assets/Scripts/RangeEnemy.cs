using UnityEngine;
using System.Collections;

public class RangeEnemy : MonoBehaviour {

    public EnemyController baseObj;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Range da va cham voi Player");
        }
    }
}
