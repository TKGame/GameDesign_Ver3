using UnityEngine;
using System.Collections;

public class HitOfBloodHaf : MonoBehaviour {

    public float speedX;
    public float speedY;
    public float damge;

    public GameObject BloodHafObj;
    public float speedCurrent;
	// Use this for initialization
	void Start () {
        //BloodHafObj = GameObject.FindGameObjectWithTag("BloodHaf").gameObject;
        //float speedCurrent = BloodHafObj.GetComponent<BloodHafScripts>().speed;
        
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedX*speedCurrent,speedY); 
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == CTag.tagPlayer)
        {
            PlayerController _player = col.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
        }
        if(col.tag == "Untagged")
        {
            Destroy(this.gameObject);
        }
    }

}
