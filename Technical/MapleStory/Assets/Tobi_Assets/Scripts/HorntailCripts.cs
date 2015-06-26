using UnityEngine;
using System.Collections;

public class HorntailCripts : MonoBehaviour {

    public GameObject objCreateHitSkill1;
    public GameObject objCreateHitSkill2;

    float _timeDelayer1 =0;
    float _timeDelayer2 = 0;
	// Use this for initialization
	void Start () {
        objCreateHitSkill1.transform.Find("CreateSkill1");
        objCreateHitSkill2.transform.Find("CreateSkill2");
	}
	
	// Update is called once per frame
	void Update () {
        if ((_timeDelayer1 += Time.deltaTime) >= 2)
        {
            objCreateHitSkill1.SetActive(true);
            _timeDelayer1 = 0;
        }
        if ((_timeDelayer2 += Time.deltaTime) >= 5)
        {
            objCreateHitSkill2.SetActive(true);
            _timeDelayer2 = 0;
        }
	}
}
