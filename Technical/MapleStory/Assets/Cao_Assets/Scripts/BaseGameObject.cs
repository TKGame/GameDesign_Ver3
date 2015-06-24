using UnityEngine;
using System.Collections;

public class BaseGameObject : MonoBehaviour {

    public float HP;
    public float damge;
    public float speed;
    protected Animator _animator;
    public GameObject bullet;
    protected Rigidbody2D rigid;
    public GameObject item;

    public bool isHP = false;
    public bool isMana = false;

    public bool isDie =false;
    void Awake()
    {
        _animator = GetComponent<Animator>();
        //rigid = GetComponent<Rigidbody2D>();
    }
	
    //public void Flip()
    //{
    //    Vector3 theScale = transform.localScale;
    //    theScale.x *= -1;
    //    transform.localScale = theScale;
    //}
    public virtual void Hit(float _damge)
    {
        HP -= _damge;
    }
    public virtual void Actack()
    {

    }
    public virtual void Die()
    {
        if (HP <= 0)
        {
            isDie = true;
            speed = 0;
            _animator.SetBool("isDie", true);
            if (rigid != null)
                rigid.gravityScale = 0;
            BoxCollider2D _box = GetComponent<BoxCollider2D>();
            if (_box != null)
            {
                _box.enabled = false;
            }
        }
    }

    public void CreateItem()
    {
        if (isHP || isMana)
        {
            if (item != null)
            {
                Instantiate(item, transform.position, Quaternion.identity);
            }
        }
    }
    
}
