using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemy : MonoBehaviour {
    public List<GameObject> listEnemy;
    //public bool isSnail;
    //public bool isMusroom;
    //public bool isDrexton;
    //public bool isHaf;
    //public bool isStone;
    //public bool isNependeath;

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
        //Debug.Log(_objectTarger.tag);
        if(_objectTarger != null)
        {
            obj = new GameObject();
            obj = _objectTarger;
            //Debug.Log(obj.tag);
            obj.GetComponent<BaseEnemyScripts>().distanceMove = dis_Move;
            obj.GetComponent<BaseEnemyScripts>().isMove = is_Move;
            obj.GetComponent<BaseEnemyScripts>().isMana = isCreateMana;
            obj.GetComponent<BaseEnemyScripts>().isHP = isCreateHP;
        }else
        {
            Debug.Log("isnull");
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if(_objectTarger.GetComponent<BaseEnemyScripts>().isDie && _objectTarger != null)
        //{
        //    isCreateNewEnemy = true;
        //    //Debug.Log(isCreateNewEnemy);
        //}

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
                _objectTarger.GetComponent<BaseEnemyScripts>().distanceMove = dis_Move;
                _objectTarger.GetComponent<BaseEnemyScripts>().isMove = is_Move;
                _objectTarger.GetComponent<BaseEnemyScripts>().isMana = isCreateMana;
                _objectTarger.GetComponent<BaseEnemyScripts>().isHP = isCreateHP;
                _timeDelay = 0;
                //obj = new GameObject();
                obj = _objectTarger;
            }
        }
	}
}
