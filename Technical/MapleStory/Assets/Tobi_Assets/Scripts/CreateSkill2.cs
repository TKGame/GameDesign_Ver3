using UnityEngine;
using System.Collections;

public class CreateSkill2 : MonoBehaviour {

    public GameObject objSkill;

    public Transform tranformCreateSkill;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    public void SetFrameFinal()
    {
        gameObject.SetActive(false);
    }

    public void CreateHitSkill2()
    {
        GameObject obj1 = Instantiate(objSkill, tranformCreateSkill.position, Quaternion.identity) as GameObject;

        GameObject obj2 = Instantiate(objSkill, new Vector3(tranformCreateSkill.position.x + 5, tranformCreateSkill.position.y), Quaternion.identity) as GameObject;
        
        GameObject obj3 = Instantiate(objSkill, new Vector3(tranformCreateSkill.position.x - 3, tranformCreateSkill.position.y), Quaternion.identity) as GameObject;
    }
}
