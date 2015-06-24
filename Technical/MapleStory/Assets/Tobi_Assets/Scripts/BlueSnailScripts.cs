using UnityEngine;
using System.Collections;

public class BlueSnailScripts : BaseEnemyScripts {

    //public bool inAroundOfPlayer = false;
    bool _facingRight = true;
    public bool isAttack = false;

    float _timeDelay = 0;
    public float dis_TimeDelay = 3.0f;
    void Start()
    {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;
        //rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
    public void UpdateStatusMove()
    {
        if (inAroundOfPlayer == false)                    // nếu nằm ngoài vùng bao
        {
            if(isMove)
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

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.tag == CTag.tagPlayer)
        {
            isAttack = true;
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.Hit(damge);
            }
        }
        if(colEnter.tag == CTag.tagGound2)
        {
            Flip();
        }
    }
    void OnTriggerStay2D(Collider2D collStay)
    {
        if (collStay.tag == "Player")
        {
            isAttack = true;
            //rigid.AddForce(new Vector2(2,0));
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        isAttack = false;
    }
}
