using UnityEngine;
using System.Collections;

public class BoomController : BaseEnemyScripts {

    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("no booom");
        if (col.tag == "Player")
        {
            PlayerController _player = col.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
            _animator.SetBool("isAttack", true);
        }
    }
}
