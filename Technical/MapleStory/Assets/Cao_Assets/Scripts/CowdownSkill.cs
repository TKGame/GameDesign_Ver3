using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CowdownSkill : MonoBehaviour {

    private Image imageCowdown;//Image cowdown
    public float timeCowdown;//time cowdown tung Skill
    private float timeDelay;
    private float timeCowdownStart;
	// Use this for initialization
	void Start () {
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
        CountDown();
	}
    public void ResetTimeCountdown()
    {
        imageCowdown.fillAmount = 1;
    }

    void CountDown()
    {
        imageCowdown.fillAmount -= 1 / timeCowdownStart * Time.deltaTime;
    }
    //kiem tra thoi gian cowdown da xong chwua 
    public bool SkillCowdown()
    {
        if (imageCowdown != null)
        {
            if (imageCowdown.fillAmount <= 0)
            {
                return true;
            }
        }
        return false;
    }
    //lay time cowdown start
    public float GetTimeDelayStart()
    {
        return timeCowdownStart;
    }
}
