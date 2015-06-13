using UnityEngine;
using System.Collections;

public class CBlueDragonScripts : BaseEnemyScripts {
    float _timeDelay = 0.0f;
    float dis_TimeDelay = 2.0f;

    public bool isAttack;
    bool _facingRight = true;

    //public bool inAroundOfPlayer = false;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null)
        {
            Die();

            if (isAttack == false)
            {
                if ((_timeDelay += Time.deltaTime) >= dis_TimeDelay && inAroundOfPlayer == false)
                {
                    isMove = !isMove;
                    _timeDelay = 0;
                }
                UpdateStatusMove();
            }
            else
            {
                _animator.SetBool("isAttack", true);
            }
        }
	}

    public void UpdateStatusMove()
    {
        if (inAroundOfPlayer == false)                    // nếu nằm ngoài vùng bao
        {
            Move(speed);
            if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
            {
                Flip();
            }
        }
        else                                            // nếu nằm trong vùng bao
        {
            if (playerObj.transform.position.x < transform.position.x && speed > 0 || playerObj.transform.position.x > transform.position.x && speed < 0)
            {
                if (_facingRight)
                {
                    _facingRight = !_facingRight;
                    Flip();
                }
                else
                    _facingRight = !_facingRight;
            }

            Move(speed);

            if (transform.position.x > startPosition.x + distanceMove || transform.position.x < startPosition.x - distanceMove)
            {
                startPosition = transform.position;
            }
        }
    }

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {

    }

    void OnTriggerStay2D(Collider2D collStay)
    {

    }

    void OnTriggerExit2D(Collider2D colExit)
    {

    }
    #endregion 
}
