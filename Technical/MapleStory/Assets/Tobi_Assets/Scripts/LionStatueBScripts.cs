using UnityEngine;
using System.Collections;

public class LionStatueBScripts : MonoBehaviour {

    public GameObject Attack1Info;
    public GameObject Attack1Info2;
    public GameObject Attack1Info3;

    public Transform PositionAttackInfo;

    Animator _anim;
	// Use this for initialization
	void Start () {
	    _anim = gameObject.GetComponent<Animator>();
	}

    [ContextMenu("create")]
    public void CreateHits()
    {
        Instantiate(Attack1Info,PositionAttackInfo.position,Quaternion.identity);
        Instantiate(Attack1Info2, PositionAttackInfo.position, Quaternion.identity);
        Instantiate(Attack1Info3, PositionAttackInfo.position, Quaternion.identity);
    }

    void OnTriggerStay2D(Collider2D colStay)
    {
        if(colStay.tag == "Player")
        {
            _anim.SetBool("isAttack",true);
        }
    }
    void OnTriggerExit2D(Collider2D colStay)
    {
        if (colStay.tag == "Player")
        {
            _anim.SetBool("isAttack", false);
        }
    }
}
