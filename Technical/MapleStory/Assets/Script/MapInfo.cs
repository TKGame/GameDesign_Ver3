using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapInfo : MonoBehaviour {

    public float posMinCameraX;
    public float posMinCameraY;
    public float posMaxCameraX;
    public float posMaxCameraY;

    public float posMinPlayerX;
    public float posMaxPlayerX;
    public float posMinPlayerY;
    public float posMaxPlayerY;

    public List<GameObject> listEnemy;

    public GameObject nextLevel;

    public Vector3 posPlayerStart;


    private PlayerController player;
    private Camera _camera;
    public int canh = 0;
    void Awake()
    {
        player = gameObject.GetComponentInParent<Level>()._player;
        _camera = gameObject.GetComponentInParent<Level>()._camera;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        LimitCamera();
        for (int i = 0; i < listEnemy.Count; i++)
        {
            if (listEnemy[i] == null)
            {
                listEnemy.Remove(listEnemy[i]);
            }
        }
        //LimitPlayer();

	}
    void LimitCamera()
    {
        if (_camera != null)
        {
            if (_camera.transform.position.x < posMinCameraX)
            {
                _camera.transform.position = new Vector3(posMinCameraX, _camera.transform.position.y, _camera.transform.position.z);
            }
            if (_camera.transform.position.x > posMaxCameraX)
            {
                _camera.transform.position = new Vector3(posMaxCameraX, _camera.transform.position.y, _camera.transform.position.z);
            }
            if (_camera.transform.position.y < posMinCameraY)
            {
                _camera.transform.position = new Vector3(_camera.transform.position.x, posMinCameraY, _camera.transform.position.z);
            }
            if (_camera.transform.position.y > posMaxCameraY)
            {
                _camera.transform.position = new Vector3(_camera.transform.position.x, posMaxCameraY, _camera.transform.position.z);
            }
        }
    }
    public void LimitPlayer()
    {
        if (player != null)
        {
            if (player.transform.position.x < posMinPlayerX || player.transform.position.x > posMaxPlayerX)
            {
                player.isMove = false;
            }
            else
            {
                player.isMove = true;
            }
        }
    }
    public void CheckUpLevel()
    {
        if (listEnemy.Count <= 0)
        {
            OpenNextLevel();
            if (player != null)
            {
                if (player.nextLevel == true)
                {
                    canh++;
                    checkUpLevel = true;
                }
            }
        }
 
    }
    public bool checkUpLevel = false;
    public void OpenNextLevel()
    {
        nextLevel.SetActive(true);
    }
    public void SetLevel()
    {
        player.transform.position = posPlayerStart;
       
    }
}
