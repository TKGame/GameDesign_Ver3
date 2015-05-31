using UnityEngine;
using System.Collections;

public class HitOfLionStatueB : MonoBehaviour {

    // van toc di chuyen cua hit
    public float speedMoveX;
    public float speedMoveY;

    Animator _anim;

    void Start()
    {
        _anim = gameObject.GetComponent<Animator>();
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedMoveX, speedMoveY);   
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            speedMoveX = 0;  
        }
        if(col.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
