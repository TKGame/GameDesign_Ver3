using UnityEngine;
using System.Collections;

public class BlueMushroomScripts : BaseEnemyScripts {
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        
	}
	
	// Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
            RunUpdateEnemy(transform);
        }
    }

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Player")
        {
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
        }
        onTriggerEnter2D(colEnter);
    }
    void OnTriggerStay2D(Collider2D collStay)
    {
        
        onTriggerStay2D(collStay);
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        onTriggerExit2D(colExit);
    }
}
