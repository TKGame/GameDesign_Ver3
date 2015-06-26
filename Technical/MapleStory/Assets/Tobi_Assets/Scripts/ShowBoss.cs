using UnityEngine;
using System.Collections;

public class ShowBoss : MonoBehaviour {
    public GameObject objBoss;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == CTag.tagPlayer)
        {
            //Debug.Log("show boss");
            //objBoss.GetComponent<ErgothScripts>();
            objBoss.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
