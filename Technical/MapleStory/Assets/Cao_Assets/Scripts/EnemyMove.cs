using UnityEngine;
using System.Collections;

public class EnemyMove : EnemyController {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Die();
        Move();
	}
    void Move()
    {
        gameObject.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
}
