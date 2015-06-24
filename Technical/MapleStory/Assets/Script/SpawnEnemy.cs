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
    public bool isCreateNewEnemy = false;
    GameObject _objectTarger;
    GameObject _objectTarger1;
    float _timeDelay = 0;
    public float _distanceTimedelay = 5.0f;
	// Use this for initialization
	void Start () {
        _objectTarger = Instantiate(listEnemy[indexCreateEnemy], transform.position, Quaternion.identity) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
	    if(_objectTarger != null && _objectTarger.GetComponent<BaseEnemyScripts>().isDie )
        {
            isCreateNewEnemy = true;
            Debug.Log(isCreateNewEnemy);
        }
        if(isCreateNewEnemy)
        {
            if ((_timeDelay += Time.deltaTime) >= _distanceTimedelay)
            {
                isCreateNewEnemy = false;
                _objectTarger = Instantiate(listEnemy[indexCreateEnemy], transform.position, Quaternion.identity) as GameObject;
                ///_objectTarger1 = Instantiate(listEnemy[indexCreateEnemy], transform.position, Quaternion.identity) as GameObject;
                //_objectTarger1.GetComponent<BaseEnemyScripts>().distanceMove  += 2;
                _timeDelay = 0;
            }
        }
	}
}
