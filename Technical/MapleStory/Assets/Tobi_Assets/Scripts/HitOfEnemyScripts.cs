using UnityEngine;
using System.Collections;

public class HitOfEnemyScripts : MonoBehaviour {
    public Animator _anim;

    public float timeLife;

    public float damgeRocket;

    Collider2D BoxOfHit;

    bool isCollision = false;
    // Use this for initialization
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        Destroy(gameObject,timeLife);
        BoxOfHit = gameObject.GetComponent<Collider2D>();
    }

    public virtual void OnTriggerEnter2D(Collider2D colEnter)
    {
        if(colEnter.tag == CTag.tagPlayer && isCollision == false)
        {
            isCollision = true;
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            _player.Hit(damgeRocket);
            //Destroy(gameObject);
            //BoxOfHit.enabled = false;
        }
    }

    public void DestroyWhenDie()
    {
        Destroy(this.gameObject);
    }

}
