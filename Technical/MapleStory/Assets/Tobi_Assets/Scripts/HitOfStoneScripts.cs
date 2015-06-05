using UnityEngine;
using System.Collections;

public class HitOfStoneScripts : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}

    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            gameObject.SetActive(false);
        }
    }
}
