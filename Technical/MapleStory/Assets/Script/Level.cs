using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public PlayerController _player;
    public BattleCameraMovement battleCamera;
    public List<GameObject> listCanh;
    public List<GameObject> listLevel;

    private int level = 0;
    public int canh = 0;

    void Awake()
    {

        
    }
	// Use this for initialization
	void Start () {
        NextLevel();
	}
	
	// Update is called once per frame
	void Update () {
	}
    void OnTriggerEnter2D(Collider2D col)
    {
       
    }

    public void NextLevel()
    {
        GameObject map1 = Instantiate(listCanh[canh], Vector3.zero, Quaternion.identity) as GameObject;
        map1.transform.SetParent(transform);
        map1.transform.localScale = new Vector3(1, 1, 0);
        map1.transform.localPosition = new Vector3(0, 0, 0);

    }

}
