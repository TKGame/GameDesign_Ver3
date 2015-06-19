using UnityEngine;
using System.Collections;

public class HitOfErgoth : HitOfEnemyScripts {

    Collider2D BoxCollider;
    void Start()
    {
        BoxCollider = gameObject.GetComponent<Collider2D>();
    }
    void OnTriggerEnter2D(Collider2D colEnter)
    {
        if (colEnter.gameObject.tag == CTag.tagPlayer)
        {
            BoxCollider.enabled = false;
            PlayerController _player = colEnter.gameObject.GetComponent<PlayerController>();
            _player.Hit(damgeRocket);
        }
    }
}
