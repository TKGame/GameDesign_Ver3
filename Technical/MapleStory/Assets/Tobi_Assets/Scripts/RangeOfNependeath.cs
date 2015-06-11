using UnityEngine;
using System.Collections;

public class RangeOfNependeath : MonoBehaviour {

    public GameObject objNependeath;
    // Use this for initialization
    void Start()
    {
        objNependeath = transform.parent.gameObject;
    }

    void OnTriggerStay2D(Collider2D colEnter)
    {
        if (colEnter.tag == "Player")
        {
            objNependeath.GetComponent<NependeathScripts>().isGrow = true;
            objNependeath.GetComponent<NependeathScripts>().isAttack = true;
        }
    }

    void OnTriggerExit2D(Collider2D colExit)
    {
        if (colExit.tag == "Player")
        {
            objNependeath.GetComponent<NependeathScripts>().isAttack = false;
        }
    }
}
