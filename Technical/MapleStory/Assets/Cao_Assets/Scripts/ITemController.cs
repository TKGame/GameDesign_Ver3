using UnityEngine;
using System.Collections;

public class ITemController : MonoBehaviour {

    public float Hp;
    public float Mana;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerController _player = col.GetComponent<PlayerController>();
            if (_player != null)
            {
                _player.AddHPandMana(Hp, Mana);
                Destroy(gameObject);
            }
        }
    }
}
