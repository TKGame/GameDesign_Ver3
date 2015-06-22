using UnityEngine;
using System.Collections;

public class MapMovePingPong : MonoBehaviour {

    public float distance = 6.0f;
    public float speed;
    public bool isUp;
    private Vector3 posStart;
    private GameObject _player;
    public Transform check;
    void Start()
    {
        posStart = transform.position;
    }
	// Update is called once per frame
	void Update () {
        Move();
    }
    void Move()
    {
        
        if (isUp == true)
        {
            //gameObject.transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time, distance), transform.position.z);
            gameObject.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            if (Vector3.Distance(transform.position, posStart) >= distance)
            {
                speed = -speed;
            }
        }
        else
        {
            Debug.Log(transform.position);
            //gameObject.transform.position = new Vector3(Mathf.PingPong(Time.time, distance), transform.position.y, transform.position.z);
            gameObject.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            if (Vector3.Distance(transform.position, posStart) >= distance)
            {
                speed = -speed;                
            }
            
        }
        MovePlayer();
    }
    
    void MovePlayer()
    {
        if (_player != null)
        {
            if (isUp == true)
            {
                _player.transform.position += new Vector3(0, speed, 0) * Time.deltaTime;
            }
            else
            {
                _player.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Player")
        {
            _player = col.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _player = null;
        }
    }
}
