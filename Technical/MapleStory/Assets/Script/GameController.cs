using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public bool blookSkillArrow;
    public bool blookSkillFire;
    public bool blookSkillTele;

    public CowdownSkill skillFire;
    public CowdownSkill skillTele;
    public CowdownSkill skillArrow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        UnlookSkillTele(blookSkillTele);
        UnlookSkillFire(blookSkillFire);
        UnlookSkillArrow(blookSkillArrow);
	}
   
    public void UnlookSkillTele(bool typeSkill)
    {
        skillTele.unlookSkill = typeSkill;
    }
    public void UnlookSkillFire(bool typeSkill)
    {
        skillFire.unlookSkill = typeSkill;
    }
    public void UnlookSkillArrow(bool typeSkill)
    {
        skillArrow.unlookSkill = typeSkill;
    }
}
