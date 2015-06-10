using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public PlayerController _player;
    public List<GameObject> listCanh;
    public List<GameObject> listLevel;
    public Camera _camera;
    private MapInfo mapInfo;
    private int level = 0;
    private int canh = 0;

    void Awake()
    {
        mapInfo = gameObject.GetComponentInChildren<MapInfo>();
        if (mapInfo != null)
        {
            mapInfo.SetLevel();
        }
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        CheckUpLevel();
	}
    void OnTriggerEnter2D(Collider2D col)
    {
       
    }
    void CheckUpLevel()
    {
        mapInfo.CheckUpLevel();
        UpCanh();
    }
    void UpCanh()
    {
        if (mapInfo.checkUpLevel == true)
        {
            if (mapInfo.canh <= listCanh.Count)
            {
                listCanh[mapInfo.canh].SetActive(true);
                listCanh[mapInfo.canh - 1].SetActive(false);
                mapInfo = gameObject.GetComponentInChildren<MapInfo>();
                mapInfo.SetLevel();
                _player.nextLevel = false;
            }
        }
    }
}
