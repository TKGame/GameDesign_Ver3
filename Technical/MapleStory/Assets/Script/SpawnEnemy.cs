using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {
    public List<GameObject> listEnemy;
  
    public int indexCreateEnemy =0;
    bool isCreateNewEnemy = false;

    

    float _timeDelay = 0;
    public float _distanceTimedelay = 5.0f;

    public float dis_Move = 0.0f;

    public bool is_Move;
    public bool isCreateHP;
    public bool isCreateMana;

    GameObject obj;
	// Use this for initialization
	void Start () {
        GameObject _objectTarger = Instantiate(listEnemy[indexCreateEnemy], transform.position, Quaternion.identity) as GameObject;
        if(_objectTarger != null)
        {
            obj = new GameObject();
            obj = _objectTarger;
            BaseEnemyScripts _base = _objectTarger.GetComponent<BaseEnemyScripts>();
            if (_base != null)
            {
                _base.distanceMove = dis_Move;
                _base.isMove = is_Move;
                _base.isMana = isCreateMana;
                _base.isHP = isCreateHP;
            }
        }else
        {
            Debug.Log("isnull");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (obj == null && isCreateNewEnemy == false )
        {
            //Debug.Log("ok");
            isCreateNewEnemy = true;
        }
        if(isCreateNewEnemy)
        {
            if ((_timeDelay += Time.deltaTime) >= _distanceTimedelay)
            {
                isCreateNewEnemy = false;
                GameObject _objectTarger = Instantiate(listEnemy[indexCreateEnemy], transform.position, Quaternion.identity) as GameObject;

                BaseEnemyScripts _base = _objectTarger.GetComponent<BaseEnemyScripts>();
                _base.distanceMove = dis_Move;
                _base.isMove = is_Move;
                _base.isHP = isCreateHP;
                _base.isMana = isCreateMana;

                _timeDelay = 0;
                //obj = new GameObject();
                obj = _objectTarger;
            }
        }
	}
}
