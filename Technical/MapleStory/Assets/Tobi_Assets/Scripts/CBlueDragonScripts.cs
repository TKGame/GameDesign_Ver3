using UnityEngine;
using System.Collections;

public class CBlueDragonScripts : BaseEnemyScripts {
    // thời gian delay
    float _timeDelay = 0.0f;
    // khoảng thời gian delay(bao nhiu s/ 1 lần)
    public float dis_TimeDelay = 3.0f;

    public bool isAttack;
    bool _facingRight = true;

    public Transform posCreateHit;
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;
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
                _animator.SetBool("isMove", isMove);
            }
        }
	}
    //các trạng thái di chuyển của enemy
    public void UpdateStatusMove()
    {
        if (inAroundOfPlayer == false)                    // nếu nằm ngoài vùng bao
        {
            if (isMove)
            {
                Move(speed);
            }
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

    public void CreateHit()
    {
        Instantiate(bullet,posCreateHit.position,Quaternion.identity);
    }

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if(colEnter.tag ==CTag.tagPlayer)
        {
            isAttack = true;
            _animator.SetBool("isAttack", true);
        }
    }

    void OnTriggerStay2D(Collider2D collStay)
    {

    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag ==CTag.tagPlayer)
        {
            isAttack = false;
            _animator.SetBool("isAttack", false);
        }
    }
    #endregion 
}
