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
        Debug.Log("Da vao");
        if (col.tag == "Enemy" || col.tag == "Boss")
        {
            EnemyController _enemy = col.GetComponent<EnemyController>();
            if (_enemy != null)
            {
                _enemy.Hit(damgeSkill);
            }
        }
    }

}
