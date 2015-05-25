using UnityEngine;
using System.Collections;

public class BlueGragonScripts : BaseGameObject {
    
    // trạng thái của enemy
    public bool isMove;

    public bool isAttack;

    // xác định trong vùng bao của Player
    // trong vùng bao của Player nếu = true , và ngược lại
    public bool inAroundOfPlayer = false;

    // đối tượng player
    public GameObject player;

    float distanceToPlayer = 0.0f;

    public float distanceMove = 0.0f;
    // vị trí ban đầu
    Vector3 _startPosition;

	// Use this for initialization
	void Start () {
        isMove = false;
        _startPosition = transform.position;
	}

	
    /// <summary>
    /// 3s sẽ đổi trạng thái 1 lần
    /// </summary>
    float timeDelay = 0.0f;
	void Update () {
        StatusMove(speed,isMove,inAroundOfPlayer);

        if((timeDelay += Time.deltaTime) >= 4.0f && isAttack== false)
        {
            isMove = !isMove;
            timeDelay = 0;
        }
        UpdateAttack(isAttack);
	}

    public void UpdateAttack(bool attack)
    {
        _animator.SetBool("isAttack", attack);
        if(attack)
        {
            isMove = false;
        }
    }

    // hàm di chuyển của enemy
    // Nếu ngoài vùng bao thì di chuyển quanh 1 vị trí 
    // nếu trong vùng bao thì di chuyển lại gần player
    public void StatusMove(float speedMove , bool move, bool inAround)
    {
        if(move)
        {
            if(inAround == false)
            {
                Move(speed);
                // di chuyển quanh vị trí ban đầu
                
            }
            else
            {
                // di chuyển đến gần player
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

   

    // va cham voi vung bao cua player
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "round")
        {
            isAttack = true;
        }
    }
}
