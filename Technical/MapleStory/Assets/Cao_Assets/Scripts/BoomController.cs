using UnityEngine;
using System.Collections;

public class BoomController : MonoBehaviour {
    public float damge;

    Animator _anim;
	// Use this for initialization
	void Start () {
        _anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == CTag.tagPlayer)
        {
            //_anim.SetBool("isAttack", true);
            _anim.SetTrigger("Bum");
            Debug.Log("bum");
            PlayerController _player = col.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
        }
    }

    public void DestroyWhenFinish()
    {
        Destroy(gameObject);
    }
}
