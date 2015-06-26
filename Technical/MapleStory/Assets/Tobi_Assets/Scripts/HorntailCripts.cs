using UnityEngine;
using System.Collections;

public class HorntailCripts : BaseEnemyScripts {

    public GameObject objCreateHitSkill1;
    public GameObject objCreateHitSkill2;

    float _timeDelayer1 =0;
    public float timeAttack1 = 2;
    public float timeAttack2 = 6;
    float _timeDelayer2 = 0;

    Animator _anim;
	// Use this for initialization
	void Start () {
        objCreateHitSkill1.transform.Find("CreateSkill1");
        objCreateHitSkill2.transform.Find("CreateSkill2");
        _anim = gameObject.GetComponent<Animator>();
	}

    public void WakeUp()
    {
        _anim.SetTrigger("WakeUp");
    }
	
	// Update is called once per frame
	void Update () {
        if ((_timeDelayer1 += Time.deltaTime) >= timeAttack1)
        {
            objCreateHitSkill1.SetActive(true);
            _timeDelayer1 = 0;
        }
        if ((_timeDelayer2 += Time.deltaTime) >= timeAttack2)
        {
            objCreateHitSkill2.SetActive(true);
            _timeDelayer2 = 0;
        }
        Die();
	}
}
