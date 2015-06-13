using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NependeathScripts : BaseEnemyScripts {
    public GameObject objHitOfNependeath;
    public Transform posCreateHit;
    public bool isAttack = false;
    public bool isGrow = false;

    public int numHit = 5;
    public List<GameObject> listHit;
	// Use this for initialization
	void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        if(playerObj.transform.position.x>transform.position.x)
        {
            Flip();
        }
        // tạo các prefabs đạn để bắn
        CreateHit(numHit);
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

    public void SetAnimatorRegen()
    {
        _animator.SetTrigger("stand");
    }

    public void CreateHit(int n)
    {
        listHit = new List<GameObject>();
        for (int i = 0; i < n;i++)
        {
            GameObject obj = Instantiate(objHitOfNependeath, posCreateHit.position, Quaternion.identity) as GameObject;
            listHit.Add(obj);
            obj.transform.SetParent(transform);
            obj.SetActive(false);
        } 
    }

    [ContextMenu("create")]
    public void SetActiveAttack()
    {
        GameObject objHit = GetObjectHitFromList();
        objHit.SetActive(true);
        objHit.transform.position = posCreateHit.position;
        objHit.transform.SetParent(transform);
    }

    public GameObject GetObjectHitFromList()
    {
        foreach(GameObject obj in listHit)
        {
            if(!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
