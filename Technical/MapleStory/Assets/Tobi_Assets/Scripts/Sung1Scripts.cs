using UnityEngine;
using System.Collections;

public class Sung1Scripts : MonoBehaviour {

    public GameObject bullet;

    public Transform tranformCreateBullet;

    float _timeDelay = 0;
    public float disTimeDelay = 4.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if((_timeDelay+= Time.deltaTime) >= disTimeDelay)
        {
            Instantiate(bullet,tranformCreateBullet.position,Quaternion.identity);
            _timeDelay = 0;
        }
	}
}
