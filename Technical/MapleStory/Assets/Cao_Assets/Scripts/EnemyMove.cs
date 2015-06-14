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
        
        //gameObject.transform.position -= new Vector3(0, speedY, 0);
    }
    private bool checkGround = false;

    private float speedY = 0.1f;
    void OnTriggerStay2D(Collider2D col)
    {
       
    }
    void OnTriggerExit2D(Collider2D col)
    {
      
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Enemy da va cham voi Player");
        }
    }
}
