using UnityEngine;
using System.Collections;

public class BossController : BaseGameObject {
    // trạng thái của enemy
    public bool isMove;

    public bool isAttack;

    // xác định trong vùng bao của Player
    // trong vùng bao của Player nếu = true , và ngược lại
    public bool inAroundOfPlayer = false;

    bool _facingRight = true;

    // đối tượng player
    public GameObject player;

    float _distanceToPlayer = 0.0f;

    public float distanceMove = 0.0f;
    // vị trí ban đầu
    Vector3 _startPosition;

	// Use this for initialization
	void Start () {
        isMove = false;
        _startPosition = transform.position;
	}
    float timeDelay = 0.0f;

    public float distanceTimeDelay = 0.0f;

	// Update is called once per frame
	void Update () {
        _distanceToPlayer = player.transform.position.x - transform.position.x;

        UpdateStatusMove(speed, isMove, inAroundOfPlayer, _distanceToPlayer);

        UpdateAttack(isAttack, _distanceToPlayer);
	}

    /// Hàm update trạng thái tấn công của boss
    /// có 4 trạng thái tấn công 
    /// <summary>
    /// 3 trạng thái tấn công gần -> random 1=attack1 ;2 = attck3 ; 3=attack4;4 = stand;
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="distanceToPlayer"></param>
    /// 
    public void UpdateAttack(bool attack, float distanceToPlayer)
    {
        if (attack)
        {
            isMove = false;
        }
    }

    public void UpdateStatusMove(float speedMove, bool move, bool inAround, float distanceToPlayer)
    {
        if (inAround == false)                        // nếu nằm ngoài vùng bao
        {
            // di chuyển
            if ((timeDelay += Time.deltaTime) >= distanceTimeDelay && isAttack == false && inAroundOfPlayer == false)
            {
                isMove = !isMove;
                timeDelay = 0;
            }
            if (move && isAttack == false)
            {
                // di chuyển quanh vị trí ban đầu
                Move(speed);
            }
        }
        else                                        // nếu nằm trong vùng bao
        {
            
            if (isAttack == false)
            {
                if (transform.position.x >= _startPosition.x + distanceMove+1.0f || transform.position.x <= _startPosition.x - distanceMove +1.0f)
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
                else if (distanceToPlayer < 0 && speed > 0)
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

            if (distanceToPlayer < -9 || distanceToPlayer > 9)
            {
                inAroundOfPlayer = false;
            }

        }
        _animator.SetBool("isMove", move);
    }

    public void Move(float speedMove)
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

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Around")
        {
            // trong vung bao cua player
            inAroundOfPlayer = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isAttack = true;
        }
    }

    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;
        if (transform.position.x < _startPosition.x + distanceMove)
        {
            Vector3 newPos = transform.position;
            newPos.x += 0.25f;
            transform.position = newPos;
        }
        else
        {
            Vector3 newPos = transform.position;
            newPos.x -= 0.25f;
            transform.position = newPos;
        }
    }

}
