using UnityEngine;
using System.Collections;

public class BlueMushroomScripts : BaseEnemyScripts {
	// Use this for initialization
    public float jumbForce = 400.0f;

    bool isJumb = false;

	void Start () {
        InitStart();
        isMove = true;
	}
	
	// Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
            if ((timeDelay += Time.deltaTime) >= 3 && isJumb)
            {
                rigid.AddForce(new Vector2(0, jumbForce));
                timeDelay = 0;
            }
            if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
            {
                Flip();
            }
            if(isMove)
            {
                Move(speed);
            }
        }
        // update trạng thái die
        Die();
    }

    // override
    float timeDelay = 0;
    
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Player")
        {
            isMove = false;
            isJumb = true;
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
        }
    }

    void OnTriggerStay2D(Collider2D collStay)
    {
        
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        isMove = true;
        isJumb = false;
    }
}
