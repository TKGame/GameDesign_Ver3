using UnityEngine;
using System.Collections;

public class BloodHafScripts : BaseEnemyScripts {

    float _timeDelay = 0.0f;

    public Transform positionCreateHit;

    public float dis_timeDelay = 3.0f;
    GameObject _bullet;

    public Rigidbody2D rocket;

    float _startSpeed = 0;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        _bullet = rocket.gameObject;
        _bullet.GetComponent<HitOfEnemyScripts>().damgeRocket = damge;
        _startSpeed = speed;

	}
	
	// Update is called once per frame
	void Update () {
        if (playerObj != null)
        {
            if (inAroundOfPlayer)
            {
                _animator.SetBool("isAttack", true);
            }
            else
            {
                _animator.SetBool("isAttack", false);
                if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
                {
                    Flip();
                }
                if ((_timeDelay += Time.deltaTime) >= dis_timeDelay)
                {
                    isMove = !isMove;
                    _timeDelay = 0;
                }
                if (isMove)
                {
                    Move(speed);
                }
            }
        }
        Die();
	}

    public void SetFrameFinalHit()
    {
        _animator.SetBool("isHit", false);
        speed = _startSpeed;
    }

    [ContextMenu("create")]
    public void CreateHit()
    {
        if (speed < 0)
        {
            Rigidbody2D bulletInstance = Instantiate(rocket, positionCreateHit.position, Quaternion.identity) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(speed * 2, -2);
        }
        else
        {
            Rigidbody2D bulletInstance = Instantiate(rocket, positionCreateHit.position, Quaternion.Euler(new Vector3(0, 0, 180.0f))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(speed * 2, -2f);
        }
    }

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if(colEnter.tag == CTag.tagHitOfPlayer)
        {
            speed = 0;
            _animator.SetBool("isHit",true);
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if(colExit.tag == "Player")
        {
            _animator.SetBool("isAttack", false);
        }
    }
 
}
