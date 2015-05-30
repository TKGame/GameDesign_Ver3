using UnityEngine;
using System.Collections;

public class BlueGragonScripts : BaseGameObject {
    
    // trạng thái của enemy
    public bool isMove;

    public bool isAttack;

    // xác định trong vùng bao của Player
    // trong vùng bao của Player nếu = true , và ngược lại
    public bool inAroundOfPlayer = false;

    bool _facingRight = true;

    // đối tượng player
    private GameObject player;

    float _distanceToPlayer = 0.0f;

    public float distanceMove = 0.0f;

    public bool isBoss = false;
    // vị trí ban đầu
    Vector3 _startPosition;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").gameObject;
        isMove = false;
        _startPosition = transform.position;
	}

	
    /// <summary>
    /// 3s sẽ đổi trạng thái 1 lần
    /// </summary>
    float timeDelay = 0.0f;

    float timeDelayForAttack = 0.0f;

    public float distanceTimeDelay = 0.0f;
	void Update () {
        if (player != null)
        {
            _distanceToPlayer = player.transform.position.x - transform.position.x;

            StatusMove(speed, isMove, inAroundOfPlayer, _distanceToPlayer);

            if (isBoss)
            {
                // Update trạng thái tấn công của boss
                UpdateBossAttack(isAttack, _distanceToPlayer);

            }
            else
                UpdateEnemyAttack(isAttack, _distanceToPlayer);     // Update trạng thái tấn công của enemy
        }
	}

    public void UpdateEnemyAttack(bool attack , float distanceToPlayer)
    {
        if (attack )
        {
            isMove = false;
        }

        if (distanceToPlayer >= 2.0f || distanceToPlayer <= -2.0f)
        {
            isAttack = false;
        }
        _animator.SetBool("isAttack", attack);
    }

    /// <summary>
    /// 3 trạng thái tấn công -> random -> 1 : attack1 - 2: attack3 - 3:attack4 - 4 : stand
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="distanceToPlayer"></param>
    public void UpdateBossAttack(bool attack, float distanceToPlayer)
    {
        if (attack)
        {
            isMove = false;
            if((timeDelayForAttack += Time.deltaTime) >= 3.0f)
            {
                int rand = Random.Range(0,5);
                
                timeDelayForAttack = 0.0f;
            }
        }

    }
    
    // hàm di chuyển của enemy
    // Nếu ngoài vùng bao thì di chuyển quanh 1 vị trí 
    // nếu trong vùng bao thì di chuyển lại gần player
    public void StatusMove(float speedMove , bool move, bool inAround, float distanceToPlayer)
    {
        if(inAround == false)                        // nếu nằm ngoài vùng bao
        {
            // di chuyển
            if ((timeDelay += Time.deltaTime) >= distanceTimeDelay && isAttack == false && inAroundOfPlayer == false)
            {
                isMove = !isMove;
                timeDelay = 0;
            } 
            if(move && isAttack == false)
            {
                // di chuyển quanh vị trí ban đầu
                Move(speed);
            }
        }
        else                                        // nếu nằm trong vùng bao
        {
            if(isAttack == false)
            {
                if (isBoss && transform.position.x >= _startPosition.x + distanceMove || transform.position.x <= _startPosition.x - distanceMove)
                {
                    inAroundOfPlayer = false;
                }

                // di chuyển đến gần player
                // có 4 trường hợp xảy ra cần xử lý
                if (distanceToPlayer < 0 && speed < 0)
                {
                    Vector3 newPos = transform.position;
                    newPos.x += Time.deltaTime * speedMove;
                    transform.position = newPos;
                    move = true;                    // xet animation
                }
                else if (distanceToPlayer > 0 && speed > 0)
                {
                    Vector3 newPos = transform.position;
                    newPos.x += Time.deltaTime * speedMove;
                    transform.position = newPos;
                    move = true;                    // xet animation
                }
                else if(distanceToPlayer < 0 && speed > 0)
                {
                    if (_facingRight)
                    {
                        _facingRight = !_facingRight;
                        speed = -speed;
                        Vector3 theScale = transform.localScale;
                        theScale.x = -theScale.x;
                        transform.localScale = theScale;
                    }
                    else
                        _facingRight = !_facingRight;
                }
                else if (distanceToPlayer > 0 && speed < 0)
                {
                    if (_facingRight)
                    {
                        _facingRight = !_facingRight;
                        speed = -speed;
                        Vector3 theScale = transform.localScale;
                        theScale.x = -theScale.x;
                        transform.localScale = theScale;
                    }
                    else
                        _facingRight = !_facingRight;
                }
            }
            
            if(distanceToPlayer < -9 || distanceToPlayer > 9)
            {
                inAroundOfPlayer = false;
            }

        }
        _animator.SetBool("isMove", move);
    }

    public void Move(float speedMove )
    {
        Vector3 newPos = transform.position;
        newPos.x += Time.deltaTime * speedMove;
        transform.position = newPos;

        if (transform.position.x >= _startPosition.x + distanceMove || transform.position.x <= _startPosition.x - distanceMove)
        {
            speed = -speed;
            inAroundOfPlayer = false;
            Flip();
        }
    }

    // hàm đổi hướng di chuyển của enemy
    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;

        if(transform.position.x < _startPosition.x+distanceMove)
        {
            Vector3 newPos = transform.position;
            newPos.x += 0.2f;
            transform.position = newPos;
        }
        else
        {
            Vector3 newPos = transform.position;
            newPos.x -= 0.2f;
            transform.position = newPos;
        }
        
    }

    //private bool _facingRight = false;
    //public void FlipOneWay()
    //{
    //    if (_facingRight)
    //    {
    //        _facingRight = !_facingRight;
    //        Vector3 theScale = transform.localScale;
    //        theScale.x = -theScale.x;
    //        transform.localScale = theScale;
    //    }
    //}


    // va cham voi vung bao cua player
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Around")
        {
            // trong vung bao cua player
            inAroundOfPlayer = true;
        }
    }

    public void SetActiveAttack()
    {
        isAttack = false;
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isAttack = true;
        }
    }
}
