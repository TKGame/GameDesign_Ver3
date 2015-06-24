using UnityEngine;
using System.Collections;

public class CGameController : MonoSingleton<CGameController> {

    public GameObject startGame;

    public GameObject GamePlay;

    public GameObject control;

    public bool isLose = false;
    
    public GameObject loseGame;

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
