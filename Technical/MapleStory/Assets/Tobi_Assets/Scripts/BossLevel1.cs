using UnityEngine;
using System.Collections;

public class BossLevel1 : MonoBehaviour {

    //public GameObject Skill1;
    //public GameObject Skill2;
    ////public GameObject Skill3;

    //public Transform tranformCreateSkill1;
    //public Transform tranformCreateSkill2;
    //public Transform tranformCreateSkill3;
    // Use this for initialization

    Animator _anim;
	void Start () {
        _anim = gameObject.GetComponent<Animator>();
	}
	
    public void WakeUp()
    {
        _anim.SetTrigger("WakeUp");
    }

    //[ContextMenu("Create 1")]
    //public void CreateHitSkill1()
    //{
    //    GameObject obj1 = Instantiate(Skill1,tranformCreateSkill1.position,Quaternion.identity) as GameObject;
    //    BossSkill1 _skill1 = obj1.GetComponent<BossSkill1>();
    //    _skill1.speedX = 0;
    //    _skill1.speedY = -2;

    //    GameObject obj2 = Instantiate(Skill1, tranformCreateSkill1.position, Quaternion.identity) as GameObject;
    //    obj2.transform.eulerAngles = new Vector3(0, 0, -30);
    //    BossSkill1 _skill2 = obj2.GetComponent<BossSkill1>();
    //    _skill2.speedX = -2;
    //    _skill2.speedY = -2;

    //    GameObject obj3 = Instantiate(Skill1, tranformCreateSkill1.position, Quaternion.identity) as GameObject;
    //    obj3.transform.eulerAngles = new Vector3(0, 0, 30);
    //    BossSkill1 _skill3 = obj3.GetComponent<BossSkill1>();
    //    _skill3.speedX = 2;
    //    _skill3.speedY = -2;
    //}

    //[ContextMenu("Create 2")]
    //public void CreateHitSkill2()
    //{
    //    GameObject obj1 = Instantiate(Skill2, tranformCreateSkill2.position, Quaternion.identity) as GameObject;

    //    GameObject obj2 = Instantiate(Skill2, new Vector3(tranformCreateSkill2.position.x + 10, tranformCreateSkill2.position.y), Quaternion.identity) as GameObject;

    //    GameObject obj3 = Instantiate(Skill2, new Vector3(tranformCreateSkill2.position.x - 10, tranformCreateSkill2.position.y), Quaternion.identity) as GameObject;
 
    //}
}
