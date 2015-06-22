using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrextonScripts : BaseEnemyScripts {

    float _distanceToPlayer;

    public float dis_TimeDelay = 0.0f;

    public bool isAttack = false;

   // public bool inAroundOfPlayer = false;

    public Transform positionCreateHit;

    GameObject _bullet;

    public Rigidbody2D rocket;
    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        playerObj = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;
        _distanceToPlayer = playerObj.transform.position.x - this.transform.position.x;
        if (_distanceToPlayer >= 0)
        {
            Flip();
        } 
        _bullet = rocket.gameObject;
        _bullet.GetComponent<HitOfEnemyScripts>().damgeRocket = damge;
    }

    //public void createHit(int n)
    //{
    //    listHit = new List<GameObject>();
    //    for (int i = 0; i < n; i++)
    //    {
    //        GameObject obj = Instantiate(bullet) as GameObject;
    //        listHit.Add(obj);
    //        obj.transform.SetParent(transform);
    //        obj.SetActive(false);
    //    }
    //}

    //public GameObject GetObjectHitFromList()
    //{
    //    foreach (GameObject obj in listHit)
    //    {
    //        if (!obj.activeInHierarchy)
    //        {
    //            return obj;
    //        }
    //    }
    //    return null;
    //}

    //public void SetActiveAttack()
    //{
    //    GameObject objHit = GetObjectHitFromList();
    //    objHit.SetActive(true);
    //    objHit.transform.position = positionCreateHit.position;
    //    //objHit.transform.SetParent(transform);
    //}
    // Update is called once per frame
    void Update()
    {

        if (playerObj != null)
        {
            Die();
            if (inAroundOfPlayer)
            {
                isAttack = true;
            }
            else
                isAttack = false;
            if (!isAttack)
            {
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
    [ContextMenu ("creat hitt")]
    public void CreateHit()
    {
        if(speed < 0)
        {
            Rigidbody2D bulletInstance = Instantiate(rocket, positionCreateHit.position, Quaternion.identity) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(speed * 3, 0);
        }
        else
        {
            Rigidbody2D bulletInstance = Instantiate(rocket, positionCreateHit.position, Quaternion.Euler(new Vector3(0,0,180.0f))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(speed * 3, 0);
        }
    }

    // khi attack xong
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
        if (colEnter.tag == CTag.tagPlayer)
        {
            isAttack = true;
        }
        if(colEnter.tag == "GroundTop")
        {
            Flip();
        }
    }

    #endregion
}
