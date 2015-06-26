using UnityEngine;
using System.Collections;

public class BridgeController : MonoBehaviour {

    public float timeActive;
    private float timeDelay;
    private bool isActive;
    public Vector3 Vantoc;


	// Use this for initialization

	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
        MoveBridge();
	}
    void MoveBridge()
    {
        if (isActive == true)
        {
            if (timeDelay > timeActive)
            {
                transform.position += Vantoc;
            }
            timeDelay += Time.deltaTime;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == CTag.tagPlayer)
        {
            isActive = true;
        }
    }
}
