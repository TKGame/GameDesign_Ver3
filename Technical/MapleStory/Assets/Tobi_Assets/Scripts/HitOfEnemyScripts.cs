using UnityEngine;
using System.Collections;

public class HitOfEnemyScripts : MonoBehaviour {
    public float speedMoveX;
    public float speedMoveY;

    Animator _anim;

    public GameObject objectTarget;
	// Use this for initialization
	public void start () {
        gameObject.tag = "Hit";
        _anim =  gameObject.GetComponent<Animator>();
        float speedCurrent = objectTarget.GetComponent<BaseEnemyScripts>().speed;
        Debug.Log(speedCurrent);
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedCurrent * speedMoveX, 0);
	}

    public void DestroyWhenFinish()
    {
        Destroy(this.gameObject);
    }

    // sử dụng cho hit bay có animation die
    public void onTriggerEnter2D(Collider2D col)
    {

    }

    public void onTriggerEnter2D(Collider2D colEnter, string tagOfEnemy)
    {
        if(colEnter.gameObject.tag == tagOfEnemy)
        {
            Destroy(this.gameObject);
        }
    }
}
