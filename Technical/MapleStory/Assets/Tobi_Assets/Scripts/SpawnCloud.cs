using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnCloud : MonoBehaviour {
    public List<Sprite> listSpriteCloud;

    public float dis_TimeDelay = 3.0f;

    public Transform tranformCreateCloud;

    public GameObject cloundObj;
	// Use this for initialization
	void Start () {
	
	}
    float _timeDelay = 0.0f;
	// Update is called once per frame
	void Update () {
	    if((_timeDelay += Time.deltaTime)>=dis_TimeDelay)
        {
            int id = Random.Range(0,listSpriteCloud.Count);
            GameObject obj = Instantiate(cloundObj, tranformCreateCloud.position, Quaternion.identity) as GameObject;
            obj.GetComponent<SpriteRenderer>().sprite = listSpriteCloud[id];
            _timeDelay = 0.0f;
        }
	}
}
