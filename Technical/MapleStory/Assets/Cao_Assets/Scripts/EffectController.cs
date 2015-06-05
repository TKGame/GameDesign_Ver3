using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

    public GameObject effect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void InstanceEffectHit()
    {
        GameObject _effect = Instantiate(effect, Vector3.zero, Quaternion.identity) as GameObject;

    }
}
