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

    public GameObject effectNextLevel;
    private PlayerController player;
    private BattleCameraMovement battleCamera;
    private Level levelControl;
    void Awake()
    {
        
    }
	// Use this for initialization
	void Start () {
        player = gameObject.GetComponentInParent<Level>()._player;
        battleCamera = gameObject.GetComponentInParent<Level>().battleCamera;
        levelControl = gameObject.GetComponentInParent<Level>();
        effectNextLevel = GameObject.FindGameObjectWithTag("Effect");

        SetInfo();
	}
    public void SetInfo()
    {
        if (player != null && battleCamera != null)
        {
            player.SetPosLimit(posMinPlayerX, posMaxPlayerX, posMinPlayerY, posMaxPlayerY);
            battleCamera.SetLimitCamera(posMinCameraX, posMaxCameraX, posMinCameraY, posMaxCameraY);
        }
    }
	// Update is called once per frame
	void Update () {
        CheckUpLevel();
        for (int i = 0; i < listEnemy.Count; i++)
        {
            if (listEnemy[i] == null)
            {
                listEnemy.Remove(listEnemy[i]);
            }
        }
	}
   
   
    public void CheckUpLevel()
    {
        if (listEnemy.Count <= 0)
        {
            if (effectNextLevel != null)
            {
                EffectNextLevel _effect = effectNextLevel.GetComponent<EffectNextLevel>();
                _effect.active = true;
                if (_effect.Finish())
                {
                    levelControl.canh++;
                    if (levelControl.canh < levelControl.listCanh.Count)
                    {
                        levelControl.NextLevel();
                        SetLevel();
                        Destroy(gameObject);
                    }
                }
            }
        
        }
 
    }

    public void OpenNextLevel()
    {
        nextLevel.SetActive(true);
    }
    public void SetLevel()
    {
        player.transform.position = posPlayerStart;
        //nextLevel.SetActive(false);
        //player.nextLevel = false;
    }
}
