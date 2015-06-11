using UnityEngine;
using System.Collections;

public class HitOfNependeathScripts : MonoBehaviour {

    public float speedMoveX;
    Animator _anim;

    public GameObject objNependeath;
    // Use this for initialization
    void Start()
    {
        gameObject.tag = "Hit";
        _anim = gameObject.GetComponent<Animator>();
        objNependeath = transform.parent.gameObject;
        
        
    }

    float _timeDelay = 0.0f;
    void Update()
    {
        float speedCurrent = objNependeath.GetComponent<NependeathScripts>().speed;

        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speedCurrent * speedMoveX, 0);
        if((_timeDelay+= Time.deltaTime) >=5.0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }
}
