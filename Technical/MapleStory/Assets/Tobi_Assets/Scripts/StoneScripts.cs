using UnityEngine;
using System.Collections;

public class StoneScripts : BaseEnemyScripts {

    float _timeDelay = 0.0f;

    float dis_TimeDelay = 3.0f;

    public bool isAttack;

    bool _facingRight = true;

   // GameObject _bullet;

    public Transform posCreateHit;

    public GameObject hitInfo;

    float _startSpeed=0;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;
        hitInfo.GetComponent<HitOfStoneScripts>().damgeRocket = damge;
        _startSpeed = speed;
        //_bullet = hitInfo.gameObject;
        //_bullet.GetComponent<HitOfEnemyScripts>().damgeRocket = damge;
	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null)
        {
            Die();
 
            if (isAttack== false)
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

    public void CreateHit()
    {
        Instantiate(hitInfo, posCreateHit.position, Quaternion.identity);
        //Instantiate(bullet, new Vector2(posCreateHit.position.x + 2.5f, posCreateHit.position.y), Quaternion.identity);
        //Instantiate(bullet, new Vector2(posCreateHit.position.x - 2.5f, posCreateHit.position.y), Quaternion.identity);
    }

    public void CreateHit1()
    {
        Instantiate(hitInfo, posCreateHit.position, Quaternion.identity);
        Instantiate(hitInfo, new Vector2(posCreateHit.position.x + 2.5f, posCreateHit.position.y), Quaternion.identity);
        //Instantiate(bullet, new Vector2(posCreateHit.position.x - 2.5f, posCreateHit.position.y), Quaternion.identity);
    }

    public void CreateHit2()
    {
        //Instantiate(bullet, posCreateHit.position, Quaternion.identity);
        //Instantiate(bullet, new Vector2(posCreateHit.position.x + 2.5f, posCreateHit.position.y), Quaternion.identity);
        Instantiate(hitInfo, new Vector2(posCreateHit.position.x - 2.5f, posCreateHit.position.y), Quaternion.identity);
    }
    public void SetFrameAttackFinal()
    {
        _animator.SetBool("isAttack", false);
        isAttack = false;
    }

    public void UpdateStatusMove()
    {
        if (inAroundOfPlayer == false)                    // nếu nằm ngoài vùng bao
        {
            if(isMove)
            {
                Move(speed);
            }else
            {
                _animator.SetBool("isMove",false);
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
    public void SetFrameFinalHit()
    {
        _animator.SetBool("isHit", false);
        speed = _startSpeed;
    }

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == CTag.tagGound2)
        {
            Flip();
        }
        if(colEnter.tag == CTag.tagHitOfPlayer)
        {
            speed = 0;
            _animator.SetBool("isHit", true);
        }
    }
    void OnTriggerStay2D(Collider2D collStay)
    {
        if (collStay.tag == CTag.tagPlayer)
        {
            isAttack = true;
        }
    }

    #endregion 
}
