using UnityEngine;
using System.Collections;

public class BulletOfAttack2 : MonoBehaviour {

    public float speedBullet = 3.0f;

    public bool moveToLeft= true;

    public GameObject bossOjb;
	// Use this for initialization
	void Start () {
       
        bossOjb = GameObject.FindGameObjectWithTag("Boss").gameObject;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(bossOjb.GetComponent<CBossController>().speed * speedBullet,0.0f);
	    
    }
	
	// Update is called once per frame
    //void Update () {
    //    //if(moveToLeft)
    //    //{
    //    //    transform.Translate(Vector3.left * speedBullet * Time.deltaTime);
    //    //}
    //    //else
    //    //    transform.Translate(Vector3.right * speedBullet * Time.deltaTime);
    //    float speed = bossOjb.GetComponent<CBossController>().speed;
        
    //    transform.Translate(Vector3.right * speedBullet * Time.deltaTime *speed);
    //}
}
