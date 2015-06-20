using UnityEngine;
using System.Collections;

public class CloudScripts : MonoBehaviour {
    public float speedMove = 0.5f;

    public float timeDestroy = 15;
    void Start()
    {
        Destroy(gameObject,timeDestroy);
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime*speedMove);
	}
}
