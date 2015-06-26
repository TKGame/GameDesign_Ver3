using UnityEngine;
using System.Collections;

public class HamControll : MonoBehaviour {

    public GameObject ham;
    public GameObject stage;
    public Vector3 posPlayer;
    public bool isHam;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "JoinHam")
        {
            SetJoinHam();
        }
        if (col.tag == "OutHam")
        {
            SetOutHam();
        }
    }
    [ContextMenu("SetJoinHam")]
    void SetJoinHam()
    {
        MapInfo mapInfo = ham.GetComponent<MapInfo>();
        if (mapInfo != null)
        {
            mapInfo.SetInfo();
        }
    }
    [ContextMenu("SetOutHam")]
    void SetOutHam()
    {
        MapInfo mapInfo = stage.GetComponent<MapInfo>();
        if (mapInfo != null)
        {
            mapInfo.posPlayerStart = posPlayer;
            mapInfo.SetLevel();
            mapInfo.SetInfo();
        }
    }
}
