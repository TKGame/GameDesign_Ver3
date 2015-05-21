using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float speed;
    public float damge;
    private Rigidbody2D rigid;
    private Animator _animator;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
        rigid.velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Actack()
    {
        rigid.velocity = new Vector2(0, 0);
        _animator.SetBool("isHit", true);
    }
    public void Flip()
    { 
        speed = -speed;    
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "Boss")
        {
            //Actack();
            //EnemyController _enemy = col.GetComponent<EnemyController>();
            //_enemy.Hit(damge);
        }
        if (col.tag == "Player")
        {
            Actack();
            PlayerController _player = col.GetComponent<PlayerController>();
            _player.Hit(damge);
        }
    }
}
