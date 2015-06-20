using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NependeathScripts : BaseEnemyScripts {
    public GameObject objHitOfNependeath;
    public Transform posCreateHit;
    public bool isAttack = false;
    public bool isGrow = false;

    GameObject _bullet;
    public Rigidbody2D rocket;

    public GameObject healthObj;
	// Use this for initialization
	void Start () {
        playerObj = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;

        _bullet = rocket.gameObject;
        _bullet.GetComponent<HitOfEnemyScripts>().damgeRocket = damge;

        if(playerObj.transform.position.x>transform.position.x)
        {
            Flip();
        }
        
        healthObj.gameObject.SetActive(false);
	}

    public void SetActiveHealth()
    {
        healthObj.gameObject.SetActive(true);
    }

    // Hàm tạo các hit khi tấn công
    public void CreateHit()
    {
        if (speed < 0)
        {
            Rigidbody2D bulletInstance = Instantiate(rocket, posCreateHit.position, Quaternion.identity) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(-3, 0);
        }
        else
        {
            Rigidbody2D bulletInstance = Instantiate(rocket, posCreateHit.position, Quaternion.Euler(new Vector3(0, 0, 180.0f))) as Rigidbody2D;
            bulletInstance.velocity = new Vector2(3, 0);
        }
    }

	// Update is called once per frame
	void Update () {
	    if(playerObj != null)
        {
            if (inAroundOfPlayer)
            {
                isGrow = true;
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }
                
            if(isGrow)
            {
                _animator.SetTrigger("grow");
            }
            _animator.SetBool("isAttack", isAttack);
        }
        Die();
	}

    // sét trạng thái regen ban đầu
    public void SetAnimatorRegen()
    {
        _animator.SetTrigger("stand");
    }

    //public void CreateHit(int n)
    //{
    //    listHit = new List<GameObject>();
    //    for (int i = 0; i < n;i++)
    //    {
    //        GameObject obj = Instantiate(objHitOfNependeath, posCreateHit.position, Quaternion.identity) as GameObject;
    //        listHit.Add(obj);
    //        obj.transform.SetParent(transform);
    //        obj.SetActive(false);
    //    } 
    //}

    //[ContextMenu("create")]
    //public void SetActiveAttack()
    //{
    //    GameObject objHit = GetObjectHitFromList();
    //    objHit.SetActive(true);
    //    objHit.transform.position = posCreateHit.position;
    //    objHit.transform.SetParent(transform);
    //}

    //public GameObject GetObjectHitFromList()
    //{
    //    foreach(GameObject obj in listHit)
    //    {
    //        if(!obj.activeInHierarchy)
    //        {
    //            return obj;
    //        }
    //    }
    //    return null;
    //}
}
