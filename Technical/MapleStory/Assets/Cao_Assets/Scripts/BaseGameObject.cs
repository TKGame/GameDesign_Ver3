using UnityEngine;
using System.Collections;

public class BaseGameObject : MonoBehaviour {

    public float HP;
    public float damge;
    public float speed;
    protected Animator _animator;
    public GameObject bullet;
    public Rigidbody2D rigid;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public virtual void Hit(float _damge)
    {
        HP -= _damge;
    }
    public virtual void Actack()
    {

    }
    public virtual void Die()
    {
        if(HP <= 0 )
        {
            speed = 0;
            _animator.SetBool("isDie", true);

            //Destroy(gameObject);
            //_animator.SetBool("activeDie", true);
        }
    }
    
}
