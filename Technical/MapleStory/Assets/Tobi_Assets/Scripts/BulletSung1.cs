using UnityEngine;
using System.Collections;

public class BulletSung1 : MonoBehaviour {

    public float speed = 2.0f;

    private Animator _anim ;

    public float damage;

    public float timeDestroy;
	// Use this for initialization
	void Start () {
        _anim = gameObject.GetComponent<Animator>();
        Destroy(this.gameObject,timeDestroy);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up*Time.deltaTime*speed);
	}

    public void DestroyWhenDie()
    {
        Destroy(this.gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == CTag.tagPlayer)
        {
            speed = 0;  
            PlayerController _player = col.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damage);
            }
            _anim.SetTrigger("isBum");
        }
    }
}
