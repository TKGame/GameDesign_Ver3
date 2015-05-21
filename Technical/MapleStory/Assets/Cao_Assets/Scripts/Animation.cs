using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

    public EnemyShoot _enemyShoot;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void Finish()
    {
        Destroy(gameObject);
    }
    void Instance()
    {
        if (_enemyShoot != null)
            _enemyShoot.InstantiateBullet();
    }
}
