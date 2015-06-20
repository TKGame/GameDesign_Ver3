using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CowdownSkill : MonoBehaviour {
    public GameController gameController;
    private Image imageCowdown;//Image cowdown
    public float timeCowdown;//time cowdown tung Skill
    private float timeDelay;
    private float timeCowdownStart;
    public bool unlookSkill;

    private float kill = 1;
	// Use this for initialization
	void Start () {
        active = true;
        imageCowdown = gameObject.GetComponent<Image>();
        timeCowdownStart = timeCowdown;
	}
	
	// Update is called once per frame
	void Update () {
        //if (timeDelay >= 1 && timeCowdown > 0)
        //{
        //    timeCowdown -= 1;
        //    timeDelay = 0;
        //}
        //timeDelay += Time.deltaTime;
        //imageCowdown.fillAmount = timeCowdown * 1 / timeCowdownStart;
        if (unlookSkill == true)
        {
            CountDown();
            if (active == true)
                imageCowdown.fillAmount = kill;
            else
                imageCowdown.fillAmount = 1;
        }
	}
    public bool active = true;
    public void ResetTimeCountdown()
    {
        kill = 1;
    }

    void CountDown()
    {
        kill -= 1 / timeCowdownStart * Time.deltaTime;
    }
    //kiem tra thoi gian cowdown da xong chwua 
    public bool SkillCowdown()
    {
        if (imageCowdown != null)
        {
            if (kill <= 0)
            {
                return true;
            }
        }
        return false;
    }
    public void SetSkill()
    {
        imageCowdown.fillAmount = 1; 
    }
    //lay time cowdown start
    public float GetTimeDelayStart()
    {
        return timeCowdownStart;
    }
}
