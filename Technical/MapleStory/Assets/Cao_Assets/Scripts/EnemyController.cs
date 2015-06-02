using UnityEngine;
using System.Collections;

public class EnemyController : BaseGameObject {

    // biến xác định di chuyển
    public bool isMove;

	// Use this for initialization
	void Start () {
        isMove = false;
	}
	
	// Update is called once per frame
	void Update () {
        Die();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _animator.SetBool("actack", true);
        }
        if (col.tag == "Bullet")
        {
            BulletController _bullet = col.GetComponent<BulletController>();
            Hit(_bullet.damge);
        }
    }
}
