using UnityEngine;
using System.Collections;

public class ErgothScripts : MonoBehaviour {

    float _timeDelay = 0.0f;
    int _indexAttack=0;
    Animator _anim;
    float _distanceToPlayer =0;

    public bool attack = false;
    public float distanceTimeAttack = 0.0f;
    GameObject _player;
    public int minRandom;
    public int maxRandom;
    public GameObject objHitAttack1;
    public GameObject objHitAttack2;
    public GameObject objHitAttack3;
	// Use this for initialization
	void Start () {
	    _anim = gameObject.GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player").gameObject;
	}

    public void Init()
    {
        Instantiate(objHitAttack1);
        Instantiate(objHitAttack2);
        Instantiate(objHitAttack3);
        objHitAttack1.SetActive(false);
        objHitAttack2.SetActive(false);
        objHitAttack2.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        _distanceToPlayer = Mathf.Abs(_player.transform.position.x - transform.position.x);
        if (_distanceToPlayer < 12)
        {
            attack = true;
        }
        else
            attack = false;
	    if(attack)
        {
            if((_timeDelay += Time.deltaTime) >= distanceTimeAttack)
            {
                _indexAttack = Random.Range(minRandom,maxRandom);
                _anim.SetBool("isAttack"+_indexAttack,true);
                _timeDelay = 0.0f;
            }
        }
	}

    public void SetAnimator()
    {
        _anim.SetBool("isAttack" + _indexAttack, false);
    }

    public void CreateHitAttack1()
    {
        Vector2 newPos = new Vector2();
        newPos.y = transform.position.y - 5;
        newPos.x = Random.Range(transform.position.x - 15,transform.position.x-5);
        Instantiate(objHitAttack1,newPos,Quaternion.identity);
        Instantiate(objHitAttack1, new Vector2(newPos.x+3,newPos.y), Quaternion.identity);
        Instantiate(objHitAttack1, new Vector2(newPos.x + 6, newPos.y), Quaternion.identity);
    }

    public void CreateHitAttack2()
    {
        Vector2 newPos = new Vector2();
        newPos.y = transform.position.y - 5;
        newPos.x = Random.Range(transform.position.x - 15, transform.position.x - 5);
        Instantiate(objHitAttack2, newPos,Quaternion.identity);
        Instantiate(objHitAttack2, new Vector2(newPos.x+4,newPos.y), Quaternion.identity);
        Instantiate(objHitAttack2, new Vector2(newPos.x + 9, newPos.y), Quaternion.identity);
    }

    public void CreateHitAttack3()
    {
        Vector2 newPos = new Vector2();
        newPos.y = transform.position.y - 5;
        newPos.x = Random.Range(transform.position.x - 15, transform.position.x - 5);
        Instantiate(objHitAttack3,newPos, Quaternion.identity);
        Instantiate(objHitAttack3, new Vector2(newPos.x + 3, newPos.y+1), Quaternion.identity);
        Instantiate(objHitAttack3, new Vector2(newPos.x+6,newPos.y), Quaternion.identity);
    }
}
