using UnityEngine;
using System.Collections;

public class ErgothScripts : BaseEnemyScripts {

    float _timeDelay = 0.0f;
    int _indexAttack=0;
    Animator _anim;

    //public bool attack = false;
    public float distanceTimeAttack = 0.0f;
    public GameObject objPlayer;
    public int minRandom;
    public int maxRandom;

    public GameObject objHitAttack1;
    public GameObject objHitAttack2;
    public GameObject objHitAttack3;

    public GameObject objHitSkill2;
	// Use this for initialization
	void Start () {
	    _anim = gameObject.GetComponent<Animator>();
        objPlayer = GameObject.FindGameObjectWithTag(CTag.tagPlayer).gameObject;

        
        //objHitAttack1.GetComponent<HitOfErgoth>().damgeRocket = damge;
        //objHitAttack2.GetComponent<HitOfErgoth>().damgeRocket = damge;
        //objHitAttack3.GetComponent<HitOfErgoth>().damgeRocket = damge;
        //objHitSkill2.GetComponent<HitOfErgoth>().damgeRocket = damge + 5;
	}
	
    public void SetFrameFinalRegen()
    {
        _anim.SetTrigger("isShow");
    }

	// Update is called once per frame
	void Update () {
	    if(inAroundOfPlayer)
        {
            if((_timeDelay += Time.deltaTime) >= distanceTimeAttack)
            {
                _indexAttack = Random.Range(minRandom,maxRandom);
                _anim.SetBool("isAttack"+_indexAttack,true);
                _timeDelay = 0.0f;
            }
        }
        else
            _anim.SetBool("isAttack" + _indexAttack, false);
	}

    public void SetFrameAttackFinal()
    {
        _anim.SetBool("isAttack" + _indexAttack, false);
    }

    public void CreateHitAttack1()
    {
        Vector2 newPos = new Vector2();
        newPos.y = transform.position.y - 4;
        newPos.x = Random.Range(transform.position.x - 15,transform.position.x-3);
        Instantiate(objHitAttack1,newPos,Quaternion.identity);
        Instantiate(objHitAttack1, new Vector2(newPos.x+5,newPos.y), Quaternion.identity);
        Instantiate(objHitAttack1, new Vector2(newPos.x + 10, newPos.y), Quaternion.identity);
    }

    public void CreateHitAttack2()
    {
        Vector2 newPos = objPlayer.transform.position;
        newPos.y = transform.position.y - 5;
        //newPos.x = Random.Range(transform.position.x - 15, transform.position.x - 5);
        Instantiate(objHitAttack2, newPos,Quaternion.identity);
        Instantiate(objHitAttack2, new Vector2(newPos.x+4,newPos.y), Quaternion.identity);
        Instantiate(objHitAttack2, new Vector2(newPos.x + 8, newPos.y), Quaternion.identity);
    }

    public void CreateHitAttack3()
    {
        Instantiate(objHitAttack3, new Vector2(objPlayer.transform.position.x, objPlayer.transform.position.y +1), Quaternion.identity);
        Instantiate(objHitAttack3, new Vector2(objPlayer.transform.position.x + 4, objPlayer.transform.position.y), Quaternion.identity);
        Instantiate(objHitAttack3, new Vector2(objPlayer.transform.position.x - 4, objPlayer.transform.position.y), Quaternion.identity);
    }
    public void CreateHitSkill2()
    {
        Vector2 newPos = transform.position;
        newPos.y = transform.position.y-1;
        //newPos.x = Random.Range(transform.position.x - 15, transform.position.y-0.5f);
        Instantiate(objHitSkill2, newPos, Quaternion.identity);
        Instantiate(objHitSkill2, new Vector2(newPos.x + 7, newPos.y), Quaternion.identity);
        Instantiate(objHitSkill2, new Vector2(newPos.x - 7, newPos.y), Quaternion.identity);
    }
}

