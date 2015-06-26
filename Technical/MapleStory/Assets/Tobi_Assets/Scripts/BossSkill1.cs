using UnityEngine;
using System.Collections;

public class BossSkill1 : MonoBehaviour {
    Animator _anim;
    public float speedX;
    public float speedY;

    public float damge;

    public bool isMove = false;

    public float timeLife;
	// Use this for initialization
	void Start () {
        _anim = gameObject.GetComponent<Animator>();
        Destroy(this.gameObject, timeLife);
	}
	
    public void SetFrameFinalRegen()
    {
        isMove = true;
        _anim.SetTrigger("Stand");
    }

	// Update is called once per frame
	void Update () {
	    if(isMove)
        {
            Vector3 newPos = transform.position;
            newPos.x += speedX * Time.deltaTime;
            newPos.y += speedY * Time.deltaTime;

            transform.position = newPos;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == CTag.tagPlayer)
        {
            PlayerController _player = col.gameObject.GetComponent<PlayerController>();
            _player.Hit(damge);
            Destroy(gameObject);
        }
    }

    public void DestroyWhenFinish()
    {
        Destroy(this.gameObject);
    }
}
