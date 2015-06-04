using UnityEngine;
using System.Collections;

public class CBossController : BaseEnemyScripts {
    // thời gian delay giữa 2 lần tấn công
    float _timeDelay = 0.0f;

    public Transform bulletPosition;


	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        float distance= playerObj.transform.position.x - this.transform.position.x;
        if (playerObj != null)
        {
            UpdateStatusOfBoss();
            UpdateBossShoot(distance);
            if ((_timeDelay += Time.deltaTime) >= 4.0f && inAroundOfPlayer == false && attack == false)
            {
                move = !move;
                _timeDelay = 0.0f;
            }
        }
	}

    public void Stand()
    {
        _animator.SetBool("isAttack3", false);
        _animator.SetBool("isAttack4", false);
        _animator.SetBool("isAttack2", false);
       // _animator.SetBool("isAttack1", false);
    }

    void UpdateBossShoot(float _distanceBossToPlayer)
    {
        if (Mathf.Abs(_distanceBossToPlayer) <= 11 && Mathf.Abs(_distanceBossToPlayer) >= 10.5)
        {
            _animator.SetBool("isAttack2", true);
            attack = false;
            move = false;
        }
    }

    //public void SetStartFrameAttack2()
    //{
    //    speed = 0;
    //}
    #region Xet Va Cham 

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Around")
        {
            inAroundOfPlayer = true;
            move = true;
        }
        if(col.gameObject.tag == "Player")
        {
            move = false;
        }
        //if(col.tag == "Player")
        //{
        //    _animator.SetBool("isAttack4", true);
        //}
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            move = false;
            attack = true;
            inAroundOfPlayer = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            attack = false;
            move = true;
        }

        if (coll.gameObject.tag == "Around")
        {
            inAroundOfPlayer = false;
        }
    }

    public void UpdateBossAttack()
    {
        if ((_timeDelay += Time.deltaTime) >= 3.0f)
        {
            int rand = UnityEngine.Random.Range(0, 4);

            _timeDelay = 0.0f;
        }
    }

    public void SetAnimatorAttack2()
    {
        _animator.SetBool("isAttack2", false);
    }

    public void CreateBulletWhenAttack2()
    {
        Instantiate(bullet, bulletPosition.position, Quaternion.identity);
    }
    #endregion
}
