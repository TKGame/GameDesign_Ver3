using UnityEngine;
using System.Collections;

public class EnemyShoot : EnemyController {

    public bool isMove;
    public Transform transfBullet;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Die();
        Move();
	}
    public void InstantiateBullet()
    {
        Instantiate(bullet, transfBullet.position, Quaternion.identity);
    }
    void Move()
    {
        gameObject.transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
    void Attack()
    {
        
    }
}
