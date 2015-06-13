using UnityEngine;
using System.Collections;

public class HitOfEnemyScripts : MonoBehaviour {
    Animator _anim;

    public float timeLife;

    public float damgeRocket;
    // Use this for initialization
    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        Destroy(gameObject,timeLife);
    }

    public void OnTriggerEnter2D(Collider2D colEnter)
    {
        if(colEnter.tag == "Player")
        {
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            _player.Hit(damgeRocket);
            Destroy(gameObject);
        }
    }

}
