using UnityEngine;
using System.Collections;

public class CreateSkill1 : MonoBehaviour {

    public GameObject objSkill;

    public Transform tranformCreateRight;
    public Transform tranformCreateLeft;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void SetFrameFinal()
    {
        gameObject.SetActive(false);
    }
    
    public void CreateHitSkill()
    {
        GameObject obj1 = Instantiate(objSkill, tranformCreateRight.position, Quaternion.identity) as GameObject;
        BossSkill1 _skill1 = obj1.GetComponent<BossSkill1>();
        _skill1.speedX = 0;
        _skill1.speedY = -2;

        GameObject obj2 = Instantiate(objSkill, tranformCreateRight.position, Quaternion.identity) as GameObject;
        obj2.transform.eulerAngles = new Vector3(0, 0, -30);
        BossSkill1 _skill2 = obj2.GetComponent<BossSkill1>();
        _skill2.speedX = -2;
        _skill2.speedY = -2;

        GameObject obj3 = Instantiate(objSkill, tranformCreateRight.position, Quaternion.identity) as GameObject;
        obj3.transform.eulerAngles = new Vector3(0, 0, 30);
        BossSkill1 _skill3 = obj3.GetComponent<BossSkill1>();
        _skill3.speedX = 2;
        _skill3.speedY = -2;

        // left
        GameObject obj4 = Instantiate(objSkill, tranformCreateLeft.position, Quaternion.identity) as GameObject;
        BossSkill1 _skill4 = obj4.GetComponent<BossSkill1>();
        _skill4.speedX = 0;
        _skill4.speedY = -2;

        GameObject obj5 = Instantiate(objSkill, tranformCreateLeft.position, Quaternion.identity) as GameObject;
        obj5.transform.eulerAngles = new Vector3(0, 0, -30);
        BossSkill1 _skill5 = obj5.GetComponent<BossSkill1>();
        _skill5.speedX = -2;
        _skill5.speedY = -2;

        GameObject obj6 = Instantiate(objSkill, tranformCreateLeft.position, Quaternion.identity) as GameObject;
        obj6.transform.eulerAngles = new Vector3(0, 0, 30);
        BossSkill1 _skill6 = obj6.GetComponent<BossSkill1>();
        _skill6.speedX = 2;
        _skill6.speedY = -2;
    }
}
