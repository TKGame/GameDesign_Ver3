using UnityEngine;
using System.Collections;

public class CReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public void ResetGame()
    {
        Application.LoadLevel("scene_tobi");
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
