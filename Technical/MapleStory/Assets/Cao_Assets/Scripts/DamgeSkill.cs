using UnityEngine;
using System.Collections;

public class DamgeSkill : MonoBehaviour {
    public float damgeSkill;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "Boss")
        {
            BaseEnemyScripts _enemy = col.GetComponent<BaseEnemyScripts>();
            if (_enemy != null)
            {
                _enemy.Hit(damgeSkill);
            }
        }
    }

}
