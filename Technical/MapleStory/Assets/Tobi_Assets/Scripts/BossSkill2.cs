using UnityEngine;
using System.Collections;

public class BossSkill2 : MonoBehaviour {
    public float damge;

    public GameObject objPlayer;
	// Use this for initialization
	void Start () {
        objPlayer = GameObject.FindGameObjectWithTag(CTag.tagPlayer);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == CTag.tagPlayer)
        {
            PlayerController _player = objPlayer.GetComponent<PlayerController>();
            _player.Hit(damge);
        }
    }
}
