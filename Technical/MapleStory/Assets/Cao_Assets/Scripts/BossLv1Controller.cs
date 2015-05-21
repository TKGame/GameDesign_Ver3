using UnityEngine;
using System.Collections;

public class BossLv1Controller : EnemyController {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Die();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Bullet")
        {
            BulletController _bu = col.GetComponent<BulletController>();
            Hit(_bu.damge);
        }
    }
}
