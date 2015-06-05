using UnityEngine;
using System.Collections;

public class CheatHitPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        float _damgeEnemy = gameObject.GetComponentInParent<BaseEnemyScripts>().damge;
        if (col.tag == "Player")
        {
            PlayerController _player = col.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(_damgeEnemy);
            }
        }
    }
}
