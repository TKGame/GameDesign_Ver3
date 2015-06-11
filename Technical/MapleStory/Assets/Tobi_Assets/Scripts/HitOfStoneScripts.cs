using UnityEngine;
using System.Collections;

public class HitOfStoneScripts : MonoBehaviour {
    //Collider2D BoxCollider;
    public void DestroyWhenDie()
    {
        Destroy(this.gameObject);
    }
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    if(col.gameObject.tag == "Player")
    //    {

    //    }
    //}
}
