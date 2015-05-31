using UnityEngine;
using System.Collections;

public class HitOfBloodHaf : MonoBehaviour {

    public float speedX;
    public float speedY;

    public GameObject BloodHafObj;
	// Use this for initialization
	void Start () {
        BloodHafObj = GameObject.FindGameObjectWithTag("BloodHaf").gameObject;
        float speedCurrent = BloodHafObj.GetComponent<BloodHafScripts>().speed;
        
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedX*speedCurrent,speedY); 
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }

}
