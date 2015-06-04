using UnityEngine;
using System.Collections;

public class NependeathScripts : BaseEnemyScripts {
    public GameObject objHitOfNependeath;
    public Transform posCreateHit;
	// Use this for initialization
	void Start () {
        playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        Flip();
	}
	
	// Update is called once per frame
	void Update () {
	    if(playerObj != null)
        {
            if (speed <0 && playerObj.transform.position.x > transform.position.x - 4 && playerObj.transform.position.x < transform.position.x &&
                (playerObj.transform.position.y < transform.position.y + 2.5f)
                )
            {
                attack = true;
            } else if(speed > 0 && playerObj.transform.position.x < transform.position.x + 4 && playerObj.transform.position.x > transform.position.x &&
                (playerObj.transform.position.y < transform.position.y + 2.5f))
            {
                attack = true;
            }
            else
                attack = false;
        }
        _animator.SetBool("isAttack", attack);
        Die();
	}

    void OnTriggerEnter2D(Collider2D colEnter)
    {
        onTriggerEnter2D(colEnter);
    }

    public void SetAnimatorRegen()
    {
        _animator.SetTrigger("stand");
    }

    [ContextMenu("create hit")]
    public void CreateHit()
    {
        Instantiate(objHitOfNependeath, posCreateHit.position, Quaternion.identity);
    }
}
