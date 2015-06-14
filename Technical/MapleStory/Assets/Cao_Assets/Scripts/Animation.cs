using UnityEngine;
using System.Collections;

public class Animation : MonoBehaviour {

    public EnemyShoot _enemyShoot;
    public PlayerController _playerControl;
	// Use this for initialization
	void Start () {
        _playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	
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
    void ActiveSpriteRender()
    {
        if (_playerControl != null)
        {
            _playerControl.ActiveSpriteRender();
        }
        
    }
    void FinishSkill()
    {
        if (_playerControl != null)
        {
            _playerControl.finishSkillFire = false;
        }
    }
}
