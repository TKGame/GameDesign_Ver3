using UnityEngine;
using System.Collections;

public class CGameController : MonoSingleton<CGameController> {
    // man hình start
    public GameObject startGame;
    //màn hinh gameplay
    public GameObject GamePlay;
    //màn hình control
    public GameObject control;
    // xác định thua
    public bool isLose = false;
    //mà hình thua
    public GameObject loseGame;
    // màn hình nói chuyện
    public GameObject ScreenTalking;
	// Use this for initialization
	void Start () {
        //loseGame.gameObject.SetActive(false);
        startGame.SetActive(true);
	}

    public void ResetGame()
    {
        Application.LoadLevel("Maple Story");
    }

    public void SetActivePlayGame()
    {
        startGame.gameObject.SetActive(false);
        GamePlay.SetActive(true);
        control.SetActive(true);
        loseGame.SetActive(false);
    }
    public GameObject objCharacter1;
    public void ClickButtonTiep()
    {
        Destroy(objCharacter1);
    }

    float distanceTimeLose =0.0f;
	// Update is called once per frame
	void Update () {
	    if(isLose)
        {
            if ((distanceTimeLose += Time.deltaTime) >= 0.7f)
            {
                isLose = false;
                loseGame.SetActive(true);
                return;
                distanceTimeLose = 0.0f;
            }
        }
	}
}
