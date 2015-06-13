using UnityEngine;
using System.Collections;

public class DrextonScripts : BaseEnemyScripts {

    float _timeDelay = 0.0f;
    float _distanceToPlayer;

    public float dis_TimeDelay = 0.0f;

    public bool isAttack = false;
    bool _facingRight = true;
   // public bool inAroundOfPlayer = false;

    public Transform posiotionCreateHit;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        _distanceToPlayer = playerObj.transform.position.x - this.transform.position.x;
        if (_distanceToPlayer >= 0)
        {
            Flip();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerObj != null)
        {
            distanceEnemyToPlayer = playerObj.transform.position.x - this.transform.position.x;
            if (!isAttack)
            {
                //if (Mathf.Abs(distanceEnemyToPlayer) < distanceMove && Mathf.Abs(playerObj.transform.position.y - transform.position.y) < 0.3f)
                //{
                //    inAroundOfPlayer = true;
                //}
                //else
                //    inAroundOfPlayer = false;
                //if ((_timeDelay += Time.deltaTime) >= dis_TimeDelay)
                //{
                //    isMove = !isMove;
                //    _timeDelay = 0;
                //}
                //UpdateStatusMove();

                if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
                {
                    Flip();
                }
                if (isMove)
                {
                    Move(speed);
                }
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
            if (distanceEnemyToPlayer < 0 && speed < 0 || distanceEnemyToPlayer > 0 && speed > 0)
            {
                Move(speed);
            }
            else if (distanceEnemyToPlayer < 0 && speed > 0 || distanceEnemyToPlayer > 0 && speed < 0)
            {
                if (_facingRight)
                {
                    _facingRight = !_facingRight;
                    Flip();
                }
                else
                    _facingRight = !_facingRight;
            }

            if (transform.position.x > startPosition.x + distanceMove || transform.position.x < startPosition.x - distanceMove)
            {
                startPosition = transform.position;
            }
        }
    }

    public void CreateHit()
    {
        Instantiate(bullet, posiotionCreateHit.position,Quaternion.identity);
    }

    public void SetFrameFinalAttack()
    {
        _animator.SetBool("isAttack", false);
        isMove = true;
        isAttack = false;
        Flip();
    }

    #region XetVaCham
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Player")
        {
            isAttack = true;
        }
    }

    void OnTriggerStay2D(Collider2D colEnter)
    {
        
    }

    void OnTriggerExit2D(Collider2D colExit)
    {

    }
    #endregion
}
