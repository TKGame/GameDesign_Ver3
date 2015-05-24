using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckBoxGround : MonoBehaviour {


    public List<Vector3> listBoxCheck;
    public float distans;
	// Use this for initialization
	void Start () {
        listBoxCheck = new List<Vector3>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    bool Distans(RectTransform taget)
    {
        float dis = Vector3.Distance(gameObject.transform.localPosition, taget.localPosition);
        if (dis <= distans)
            return true;
        return false;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        
        if (col.tag == "Ground")
        {
            //Debug.Log("Da va cham voi Ground");
            if (Distans((RectTransform)col.gameObject.transform))
            {
                if (!listBoxCheck.Contains(col.gameObject.transform.position))
                    listBoxCheck.Add(col.gameObject.transform.position);
            }
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Ground")
        {
            if (listBoxCheck.Contains(col.gameObject.transform.position))
            {
                listBoxCheck.Remove(col.gameObject.transform.position);
            }
        }           
    }
    public void DuyetListBoxCheck()
    {
 
    }
}
