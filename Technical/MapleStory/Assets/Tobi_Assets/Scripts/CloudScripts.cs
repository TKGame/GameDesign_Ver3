using UnityEngine;
using System.Collections;

public class CloudScripts : MonoBehaviour {
    public float speedMove = 0.5f;
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime*speedMove);
	}
}
